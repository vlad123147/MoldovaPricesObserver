﻿using HtmlAgilityPack;
using PricesObserver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricesObserver.SiteParsers.Sites
{
    public class TermoshopMdParser : SiteParserBase
    {
        protected override decimal GetPrice(HtmlDocument document)
        {
            var node = document.DocumentNode
                .SelectSingleNode("//*[starts-with(@id, \"product-\")]/div[1]/div[2]/div/div/div[2]/div/p/ins/span/text()");

            if (node == null)
            {
                throw new Exception("Could not find document node, may be Price xpath changed");
            }

            var priceString = node.InnerHtml.Replace(" ", "").Replace(".", "").Replace(",", ".").Replace("&nbsp;", "");

            return decimal.Parse(priceString);
        }
    }
}
