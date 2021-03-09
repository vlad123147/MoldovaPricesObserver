using HtmlAgilityPack;
using PricesObserver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricesObserver.SiteParsers.Sites
{
    public class InstalatorMdParser : SiteParserBase
    {
        protected override decimal GetPrice(HtmlDocument document)
        {
            //var node = document.DocumentNode
            //    .SelectSingleNode("//*[@id=\"product-313\"]/div[2]/p/ins/span/text()");

               var node =  document.DocumentNode.SelectSingleNode("//*[starts-with(@id, \"product-\")]/div[2]/p/ins/span/text()");

            //if (node == null)
            //{
            //    node = document.DocumentNode.SelectSingleNode("//*[@id=\"product-327\"]/div[2]/p/ins/span/text()");
            //}

            if (node == null)
            {
                throw new Exception("Could not find document node, may be Price xpath changed");
            }

            var priceString = node.InnerHtml.Replace("&nbsp;", "").Replace(".", "").Replace(",", ".");

            return decimal.Parse(priceString);
        }
    }
}
