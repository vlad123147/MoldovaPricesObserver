using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Nest;
using PricesObserver;
using PricesObserver.Configs;
using PricesObserver.ElasticSearch;
using PricesObserver.PriceObservers;
using PricesObserver.PriceStores;
using PricesObserver.SiteParsers;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkerService
{
	public class Program
	{
		private static PricesObserverConfiguration ObserverConfiguration;
		public static ElasticSearchConfig ElasticSearchConfig;
		public static void Main(string[] args)
		{
			Log.Logger = new LoggerConfiguration()
				.Enrich.FromLogContext()
				.WriteTo.Console()
				.WriteTo.File("logs/observer.txt")
				.CreateLogger();

			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.UseSerilog()
				.ConfigureServices((hostContext, services) =>
				{
					ReadConfiguration(hostContext);

					services.AddHostedService<Worker>();

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
				}).UseWindowsService();

		private static void ReadConfiguration(HostBuilderContext hostContext)
		{
			var configuration = new ConfigurationBuilder()
					.AddJsonFile("appsettings.json")
					.AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json")
					.AddEnvironmentVariables()
					.Build();

			ObserverConfiguration = new PricesObserverConfiguration();

			configuration.GetSection("observer").Bind(ObserverConfiguration);


			ElasticSearchConfig = new ElasticSearchConfig();
			configuration.GetSection("ElasticSearch").Bind(ElasticSearchConfig);
		}

		private static void AddElasticSearch(IServiceCollection services)
		{
			services.AddTransient<IConnectionSettingsValues>(x => ElasticClientSettingsFactory.Create(ElasticSearchConfig));
			services.AddTransient<IElasticClient, ElasticClient>();
			services.AddTransient<IPricesElasticSearchIndex, PricesElasticSearchIndex>();
		}
	}
}
