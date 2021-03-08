using HtmlAgilityPack;
using PricesObserver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricesObserver.SiteParsers.Sites
{
    public class BaiePlusParser : SiteParserBase
    {
        protected override decimal GetPrice(HtmlDocument document)
        {
            //var node = document.DocumentNode
            //    .SelectSingleNode("//*[@id=\"main_right\"]/div[1]/div/div/div/div[2]/div[2]/div[2]/span/text()");

            //if (node == null)
            //{
            //    throw new Exception("Could not find document node, may be Price xpath changed");
            //}

            //var priceString = node.InnerHtml.Replace(" ", "");

            //return decimal.Parse(priceString);

            return 0;
        }
    }
}
