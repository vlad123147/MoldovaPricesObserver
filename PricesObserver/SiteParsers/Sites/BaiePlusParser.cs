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
            var node = document.DocumentNode
                .SelectSingleNode("//*[@id=\"center_column\"]/div/div[1]/div[3]/div[2]/div[1]/ul/li[2]/span");

            if (node == null)
            {
                return 0;
            }

            var priceString = node.InnerHtml.Replace(",", ".").Replace(" ", "").Replace("MDL", "");

            return decimal.Parse(priceString);

            return 0;
        }
    }
}
