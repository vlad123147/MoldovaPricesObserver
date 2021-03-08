using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricesObserver
{
    public class PricesObserverConfiguration
    {
        public List<Product> Products { get; set; }

        public class Product
        {
            public string Name { get; set; }
            public List<string> ShopsUrl { get; set; }
        }
    }
}
