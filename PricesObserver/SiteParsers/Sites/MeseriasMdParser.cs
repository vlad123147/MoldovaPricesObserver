using HtmlAgilityPack;
using PricesObserver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricesObserver.SiteParsers.Sites
{
    public class MeseriasMdParser : SiteParserBase
    {
        protected override decimal GetPrice(HtmlDocument document)
        {
            var node = document.DocumentNode
                .SelectSingleNode("//*[@id=\"content\"]/div[1]/div[2]/ul/li[1]/h2/span");

            if (node == null)
            {
                throw new Exception("Could not find document node, may be Price xpath changed");
            }

            var priceString = node.InnerHtml.Replace(" ", "").Replace(".", "").Replace(",", ".").Replace("MDL", "");

            return decimal.Parse(priceString);
        }
    }
}
