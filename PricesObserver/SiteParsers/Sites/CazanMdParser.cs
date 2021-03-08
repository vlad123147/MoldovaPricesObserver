using HtmlAgilityPack;
using PricesObserver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricesObserver.SiteParsers.Sites
{
    public class CazanMdParser : SiteParserBase
    {
        protected override decimal GetPrice(HtmlDocument document)
        {
            throw new NotSupportedException("Requires JS");
        }
    }
}
