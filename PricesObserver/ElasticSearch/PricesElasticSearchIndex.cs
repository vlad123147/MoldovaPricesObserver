using Nest;
using PricesObserver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricesObserver.ElasticSearch
{
    public interface IPricesElasticSearchIndex
    {
        Task IndexDocument(ProductPriceFetchResult productPrice);
    }

    public class PricesElasticSearchIndex : IPricesElasticSearchIndex
    {
        private readonly IElasticClient _elastic;

        public PricesElasticSearchIndex(IElasticClient elastic)
        {
            _elastic = elastic;
        }

        public async Task IndexDocument(ProductPriceFetchResult productPrice)
        {
            IndexResponse response = _elastic.Index<ProductPriceFetchResult>(productPrice, i => i.Index("prices"));

            var debugInfo = response.DebugInformation;

            if (!response.IsValid)
            {
                throw response.OriginalException;
            }
        }
    }
}
