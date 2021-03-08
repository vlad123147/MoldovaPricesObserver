using HtmlAgilityPack;
using PricesObserver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricesObserver.SiteParsers.Sites
{
    public class TeploplusParser : SiteParserBase
    {
        protected override decimal GetPrice(HtmlDocument document)
        {
            var node = document.DocumentNode
                .SelectSingleNode("//*[@id=\"content\"]/div[1]/div[2]/ul[2]/li/div/h2");

            if (node == null)
            {
                throw new Exception("Could not find document node, may be Price xpath changed");
            }

            var priceString = node.InnerHtml.Replace(" MDL", "");

            return decimal.Parse(priceString);
        }
    }
}
