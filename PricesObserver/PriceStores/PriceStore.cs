using Microsoft.Extensions.Logging;
using PricesObserver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricesObserver.PriceStores
{
    public interface IPriceStore
    {
        Task StoreAsync(ProductPriceFetchResult productPrice);
    }

    public class PriceStore : IPriceStore
    {
        private readonly ILogger<PriceStore> _logger;

        public PriceStore(ILogger<PriceStore> logger)
        {
            _logger = logger;
        }

        public async Task StoreAsync(ProductPriceFetchResult productPrice)
        {
            try
            {
                await Task.CompletedTask;
            }
            catch (Exception e)
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(productPrice);

                _logger.LogError(e, $"Could not save {json}");
            }
        }
    }
}
