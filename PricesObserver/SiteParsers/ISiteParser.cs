using PricesObserver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricesObserver.SiteParsers
{
    public interface ISiteParser
    {
        public ProductPriceFetchResult Parse(string productName, string url);
    }
}
