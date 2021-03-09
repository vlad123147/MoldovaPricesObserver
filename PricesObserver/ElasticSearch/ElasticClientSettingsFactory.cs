using Nest;
using PricesObserver.Configs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PricesObserver.ElasticSearch
{
    public static class ElasticClientSettingsFactory
    {
        public static ConnectionSettings Create(ElasticSearchConfig elasticConfig)
        {
            ConnectionSettings settings = null;
            if (!string.IsNullOrEmpty(elasticConfig.Url))
            {
                settings = new ConnectionSettings(new Uri(elasticConfig.Url));
            }
            else
            {
                settings = new ConnectionSettings(
                    elasticConfig.CloudId,
                    new Elasticsearch.Net.BasicAuthenticationCredentials(elasticConfig.Username, elasticConfig.Password));
            }

            settings.DisableDirectStreaming(true);

            settings.OnRequestCompleted(call =>
            {
                if (call.RequestBodyInBytes != null)
                {
                    var request = Encoding.UTF8.GetString(call.RequestBodyInBytes);
                    Console.WriteLine(request);
                }
            });


            return settings;
        }
    }
}
