using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PricesObserver.PriceObservers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WorkerService
{
	public class Worker : BackgroundService
	{
		private readonly ILogger<Worker> _logger;
		private readonly IPriceObserverScheduler _priceObserverScheduler;

		public Worker(ILogger<Worker> logger, IPriceObserverScheduler priceObserverScheduler)
		{
			_logger = logger;
			_priceObserverScheduler = priceObserverScheduler;
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			while (!stoppingToken.IsCancellationRequested)
			{
				_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
				await _priceObserverScheduler.Run();
				await Task.Delay(TimeSpan.FromHours(6), stoppingToken);
			}
		}
	}
}
