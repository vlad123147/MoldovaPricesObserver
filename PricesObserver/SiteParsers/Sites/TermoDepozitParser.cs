using HtmlAgilityPack;
using PricesObserver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricesObserver.SiteParsers.Sites
{
    public class TermoDepozitParser : SiteParserBase
    {
        protected override decimal GetPrice(HtmlDocument document)
        {
            var node = document.DocumentNode
                .SelectSingleNode("//*[@id=\"price\"]");

            if (node == null)
            {
                throw new Exception("Could not find document node, may be Price xpath changed");
            }

            var priceString = node.InnerHtml;

            return decimal.Parse(priceString);
        }
    }
}
