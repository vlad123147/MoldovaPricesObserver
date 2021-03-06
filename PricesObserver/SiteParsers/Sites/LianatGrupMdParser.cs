﻿using HtmlAgilityPack;
using PricesObserver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricesObserver.SiteParsers.Sites
{
    public class LianatGrupMdParser : SiteParserBase
    {
        protected override decimal GetPrice(HtmlDocument document)
        {

            var node = document.DocumentNode
                .SelectSingleNode("//*[@id=\"item_info_box\"]/form/input[2]");

            if (node == null)
            {
                throw new Exception("Could not find document node, may be Price xpath changed");
            }

            var priceString = node.Attributes[2]?.Value;

            return decimal.Parse(priceString);
        }
    }
}
