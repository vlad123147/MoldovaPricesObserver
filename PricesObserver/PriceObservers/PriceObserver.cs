using Microsoft.Extensions.Logging;
using PricesObserver.Models;
using PricesObserver.PriceStores;
using PricesObserver.SiteParsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PricesObserver.PriceObservers
{
    public interface IPriceObserver
    {
        Task ObserveAsync(string productName, string productUrl);
    }

    public class PriceObserver : IPriceObserver
    {
        private readonly IPriceStore _priceStore;
        private readonly ISiteParserFactory _parserFactory;
        private readonly ILogger<PriceObserver> _logger;

        public PriceObserver(IPriceStore priceStore, ISiteParserFactory parserFactory, ILogger<PriceObserver> logger)
        {
            _priceStore = priceStore;
            _parserFactory = parserFactory;
            _logger = logger;
        }

        public async Task ObserveAsync(string productName, string productUrl)
        {

            try
            {
                ISiteParser parser = _parserFactory.GetInstance(productUrl);

                ProductPriceFetchResult price = parser.Parse(productName, productUrl);

                if (price.Price <= 0)
                {
                    throw new Exception("Price is negative or zero");
                }

                await _priceStore.StoreAsync(price);
            }
            catch (Exception e)
            {
                var id = Guid.NewGuid().ToString("N");

                _logger.LogError(e, $"{id} Could not observe prices on site {productUrl}");

                var price = new ProductPriceFetchResult(e.Message, id, productName, productUrl);
                await _priceStore.StoreAsync(price);
            }
        }
    }
}
