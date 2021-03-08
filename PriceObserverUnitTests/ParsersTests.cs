using FluentAssertions;
using PricesObserver.SiteParsers;
using PricesObserver.SiteParsers.Sites;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PriceObserverUnitTests
{
    public class ParsersTests: ParserUnitTest
    {
        [Theory]
        [InlineData("https://hamster.md/shop/item/view/24857", 9389)]
        [InlineData("http://baieplus.md/ru/kotly-i-gazovye-kolonki/18-cazan-immergas-eolo-star.html", 0)]
        [InlineData("http://termoformat.md/ru/immergas_eolo_star_24_3e", 11900)]
        [InlineData("http://instalator.md/shop/centrala-termica-immergas-eolo-star-24/", 10710)]
        [InlineData("https://smadshop.md/otoplenie-vodosnabzhenie/kotiol-immergas-eolo-star.html", 11900)]
        [InlineData("https://instalatii.md/product/cazan-immergas-eolo-star-24/", 10137)]
        [InlineData("https://supraten.md/centrala-termica-pe-gaz-eolo-star-24-277351-ro", 10950)]
        [InlineData("https://santehmarket.md/produs/centrala-immergas-eolo-star-24-kw/", 8900)]
        [InlineData("https://maxmart.md/ru/tovary/283313/cazan-immergas-eolo-star-24-kw", 9858)]
        [InlineData("https://magicshop.md/electrocasnice-magic-shopmd/instalatii-termice-si-sanitare/cazane-pe-gaz/cazan-immergas-eolo-star-24-kw-0018-18", 9858)]
        [InlineData("https://ogogo.md/cazan-immergas-eolo-star.html", 11900)]
        [InlineData("https://econstruct.md/ro/5871563/", 11900)]
        [InlineData("https://bigshop.md/ro/product/immergas-eolo-star-24-3e-p18877", 11900)]
        [InlineData("https://uniplast.md/ro/437044/", 11890)]
        [InlineData("https://meserias.md/ro/otoplenie-i-vodosnabjenie/kotly-otopleniya/gazovyj-kotel-immergas-eolo-star-24-kw", 10670)]
        [InlineData("https://robinet.md/ru/6075423/", 10710)]
        [InlineData("http://www.termodepozit.md/ru/product/centrala-immergas-eolo-star-24-kw/", 9990)]
        [InlineData("https://teploplus.md/index.php?route=product/product&path=103860_103903&product_id=103908", 11900)]
        [InlineData("http://cazan.md/ro/cazan-immergas/11-cazan-immergas-eolo-star-24.html", 9389)]
        [InlineData("https://jara.md/ro/5744637/", 11900)]
        public void ShouldParseExact(string url, decimal price)
        {
            ISiteParser parser = new SiteParserFactory().GetInstance(url);

            PricesObserver.Models.ProductPriceFetchResult parsedPrice = parser.Parse("test", url);

            parsedPrice.IsSuccess.Should().BeTrue();
            parsedPrice.Price.Should().Be(price);
        }
    }
}
