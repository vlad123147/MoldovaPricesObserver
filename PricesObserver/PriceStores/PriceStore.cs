using Microsoft.Extensions.Logging;
using PricesObserver.ElasticSearch;
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
        private readonly IPricesElasticSearchIndex _pricesIndex;

        public PriceStore(ILogger<PriceStore> logger, IPricesElasticSearchIndex pricesIndex)
        {
            _logger = logger;
            _pricesIndex = pricesIndex;
        }

        public async Task StoreAsync(ProductPriceFetchResult productPrice)
        {
            try
            {
                await _pricesIndex.IndexDocument(productPrice);
            }
            catch (Exception e)
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(productPrice);

                _logger.LogError(e, $"Could not save {json}");
            }
        }
    }
}
