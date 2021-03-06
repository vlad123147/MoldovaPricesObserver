﻿using HtmlAgilityPack;
using PricesObserver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricesObserver.SiteParsers.Sites
{
    public abstract class SiteParserBase : ISiteParser
    {
        public ProductPriceFetchResult Parse(string productName, string url)
        {
            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(url);

            decimal price = GetPrice(htmlDoc);

            return  new ProductPriceFetchResult(productName, url, price);
        }

        protected abstract decimal GetPrice(HtmlDocument document);

        private string GetSeller(string url)
        {
            var uri = new Uri(url);
            return uri.Host;
        }
    }
}
