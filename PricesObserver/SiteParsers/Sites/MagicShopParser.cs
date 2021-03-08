using HtmlAgilityPack;
using PricesObserver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricesObserver.SiteParsers.Sites
{
    public class MagicShopParser : SiteParserBase
    {
        protected override decimal GetPrice(HtmlDocument document)
        {
            throw new NotSupportedException("Js is required");
        }
    }
}
