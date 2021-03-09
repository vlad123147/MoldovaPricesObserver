using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricesObserver.Configs
{
    public class ElasticSearchConfig
    {
        public string CloudId { get; set; }

        public string Username { get; set; }
        public string Password{ get; set; }

        public string Url { get; set; }
    }
}
