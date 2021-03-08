using HtmlAgilityPack;
using PricesObserver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricesObserver.SiteParsers.Sites
{
    public class TermoformatMdParser : SiteParserBase
    {
        protected override decimal GetPrice(HtmlDocument document)
        {
            var node = document.DocumentNode
                .SelectSingleNode("//*[@id=\"item\"]/div[3]/div[1]/div/div[1]/span/div[1]/span");

            if (node == null)
            {
                throw new Exception("Could not find document node, may be Price xpath changed");
            }

            var priceString = node.InnerHtml;

            return decimal.Parse(priceString);
        }
    }
}
