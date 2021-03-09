using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyShop.BuildingBlocks.Infrastructure._Configuration.TransactionalCommands;
using MyShop.BuildingBlocks.Infrastructure._Configuration.TransactionalCommands.Outbox;
using Nest;
using PricesObserver.Configs;
using PricesObserver.ElasticSearch;
using PricesObserver.PriceObservers;
using PricesObserver.PriceStores;
using PricesObserver.SiteParsers;
using Quartz;
using Quartz.Impl;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricesObserver
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public PricesObserverConfiguration ObserverConfiguration { get; }
        public ElasticSearchConfig ElasticSearchConfig { get; }

        public Startup(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File("logs/observer.txt")
                .CreateLogger();

            Configuration = configuration;

            ObserverConfiguration = new PricesObserverConfiguration();

            configuration.GetSection("observer").Bind(ObserverConfiguration);


            ElasticSearchConfig = new ElasticSearchConfig();
            configuration.GetSection("ElasticSearch").Bind(ElasticSearchConfig);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.AddSerilog(dispose: true);
            });


            AddElasticSearch(services);

            services.AddTransient<PricesObserverConfiguration>((serviceProvider) => ObserverConfiguration);
            services.AddTransient<IPriceObserverScheduler, PriceObserverScheduler>();
            services.AddTransient<IPriceObserver, PriceObserver>();
            services.AddTransient<ISiteParserFactory, SiteParserFactory>();
            services.AddTransient<IPriceStore, PriceStore>();
            services.AddTransient<ProcessPricesJob>();

            services.AddQuartz(q =>
            {
                // these are the defaults
                q.UseSimpleTypeLoader();
                q.UseInMemoryStore();
                q.UseDefaultThreadPool(tp =>
                {
                    tp.MaxConcurrency = 10;
                });

                // handy when part of cluster or you want to otherwise identify multiple schedulers
                q.SchedulerId = "Scheduler-Core";

                // we take this from appsettings.json, just show it's possible
                // q.SchedulerName = "Quartz ASP.NET Core Sample Scheduler";

                // we could leave DI configuration intact and then jobs need to have public no-arg constructor
                // the MS DI is expected to produce transient job instances

                // this is default configuration if you don't alter it
                q.UseMicrosoftDependencyInjectionJobFactory(options =>
                {
                    // if we don't have the job in DI, allow fallback to configure via default constructor
                    options.AllowDefaultConstructor = true;

                    // set to true if you want to inject scoped services like Entity Framework's DbContext
                    options.CreateScope = false;
                });


                //// quickest way to create a job with single trigger is to use ScheduleJob
                //q.ScheduleJob<ProcessPricesJob>(trigger => trigger
                //    .WithIdentity("Combined Configuration Trigger")
                //    .StartAt(DateBuilder.EvenSecondDate(DateTimeOffset.UtcNow.AddSeconds(7)))
                //    .WithDailyTimeIntervalSchedule(x => x.WithInterval(10, IntervalUnit.Second))
                //    .WithDescription("my awesome trigger configured for a job with single call")
                //);

                q.AddJob<ProcessPricesJob>(j => j
                .WithIdentity("job1")
                    .StoreDurably() // we need to store durably if no trigger is associated
                    .WithDescription("my awesome job")
                );
                q.AddTrigger(t => t
                    .ForJob("job1")
                   .StartNow()
                   //.WithCronSchedule(CronScheduleBuilder.DailyAtHourAndMinute(06, 00))
                    //.WithSchedule(CronScheduleBuilder.CronSchedule("0/15 * * ? * *"))
                    .WithSimpleSchedule(x => x
                        .WithIntervalInSeconds(10)
                        .RepeatForever())
                );
            });

            // ASP.NET Core hosting
            services.AddQuartzServer(options =>
            {
                // when shutting down we want jobs to complete gracefully
                options.WaitForJobsToComplete = true;
            });
        }

        private void AddElasticSearch(IServiceCollection services)
        {
            services.AddTransient<IConnectionSettingsValues>(x => ElasticClientSettingsFactory.Create(ElasticSearchConfig));
            services.AddTransient<IElasticClient, ElasticClient>();
            services.AddTransient<IPricesElasticSearchIndex, PricesElasticSearchIndex>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World from price observer! Go to /updatePrices to force prices update");
                });
                endpoints.MapGet("/updatePrices", async context =>
                {
                    var scheduler = context.RequestServices.GetRequiredService<IPriceObserverScheduler>();
                    await scheduler.Run();
                    await context.Response.WriteAsync("Prices were updated");
                });
            });
        }
    }
}
