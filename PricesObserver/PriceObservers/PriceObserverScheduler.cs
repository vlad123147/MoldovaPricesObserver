using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricesObserver.PriceObservers
{
    public interface IPriceObserverScheduler
    {
        Task Run();
    }

    public class PriceObserverScheduler : IPriceObserverScheduler
    {
        private readonly PricesObserverConfiguration _configuration;
        private readonly IPriceObserver _priceObserver;
        private readonly ILogger<PriceObserverScheduler> _logger;

        public PriceObserverScheduler(PricesObserverConfiguration configuration, IPriceObserver siteObserver, ILogger<PriceObserverScheduler> logger)
        {
            _configuration = configuration;
            _priceObserver = siteObserver;
            _logger = logger;
        }

        public async Task Run()
        {
            foreach (var product in _configuration.Products)
            {
                _logger.LogInformation($"Processing product {product.Name} on {product.ShopsUrl.Count} websites");

                foreach (var shopUrl in product.ShopsUrl)
                {
                    _logger.LogInformation($"Processing product {product.Name} on website {shopUrl}");

                    await _priceObserver.ObserveAsync(product.Name, shopUrl);
                }
            }
        }
    }
}
