using FluentAssertions;
using PricesObserver.SiteParsers;
using PricesObserver.SiteParsers.Sites;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PriceObserverUnitTests
{
    public class ParsersTests : ParserUnitTest
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

        public void ShouldParseExact1(string url, decimal price)
        {
            ISiteParser parser = new SiteParserFactory().GetInstance(url);

            PricesObserver.Models.ProductPriceFetchResult parsedPrice = parser.Parse("test", url);

            parsedPrice.IsSuccess.Should().BeTrue();
            parsedPrice.Price.Should().Be(price);
        }

        //Immergas Eolo Mythos
        [InlineData("http://baieplus.md/ru/kotly-i-gazovye-kolonki/651-cazan-immergas-eolo-mythos.html", 11900)]
        [InlineData("http://termoformat.md/ru/immergas_eolo_mythos_24_kw_2e", 11900)]
        [InlineData("http://instalator.md/shop/cazan-immergas-eolo-mythos-24-kw/", 10710)]
        [InlineData("https://smadshop.md/otoplenie-vodosnabzhenie/kotiol-immergas-eolo-mythos.html", 13550)]
        [InlineData("https://instalatii.md/product/cazan-immergas-eolo-mythos-24-kw/", 12500)]
        [InlineData("https://kazinst.md/produs/centrale/cazane-pe-gaz/cazane-immergas/centrala-immergas-ecolo-mythos-24kw/", 11900)]
        [InlineData("https://supraten.md/centrala-termica-pe-gaz-eolo-mythos-24-277350-ro", 12789)]
        [InlineData("https://lianatgrup.md/ro/Cazane/Cazan-pe-gaz/Centrala-termica-IMMERGAS-Eolo-Mythos-24KW/2754", 11900)]
        [InlineData("https://santehmarket.md/produs/centrala-immergas-eolo-mythos-24-kw/", 10000)]
        [InlineData("https://maxmart.md/ru/tovary/283314/cazan-immergas-eolo-mythos-24-kw", 11021)]
        [InlineData("https://magicshop.md/electrocasnice-magic-shopmd/instalatii-termice-si-sanitare/cazane-pe-gaz/cazan-immergas-eolo-mythos-24-kw-2049-18", 11900)]
        [InlineData("https://econstruct.md/ro/5870977/", 13900)]
        [InlineData("https://santehproiect.md/107/", 11900)]
        [InlineData("https://bigshop.md/ro/product/immergas-eolo-mytos-24-kw-p18879", 11900)]
        [InlineData("https://nanu.md/ru/gazovye-kotly/14872-cazan-immergas-eolo-mythos-24kw.html", 12570)]
        [InlineData("https://uniplast.md/ro/437045/", 11890)]
        [InlineData("https://meserias.md/ro/otoplenie-i-vodosnabjenie/kotly-otopleniya/gazovyj-kotel-immergas-eolo-mythos-24-kw", 12990)]
        [InlineData("https://robinet.md/ru/6075424/", 12510)]
        [InlineData("http://www.termodepozit.md/ru/product/centrala-immergas-eolo-mythos-24-kw-1/", 10900)]
        [InlineData("https://teploplus.md/index.php?route=product/product&path=103860_103903&product_id=103907", 11900)]
        [InlineData("http://cazan.md/ro/cazan-immergas/186-cazan-immergas-eolo-mythos-24-2e-.html", 11900)]
        [InlineData("https://jara.md/ro/5744636/", 11900)]
        [Theory]
        public void ShouldParseExact2(string url, decimal price)
        {
            ISiteParser parser = new SiteParserFactory().GetInstance(url);

            PricesObserver.Models.ProductPriceFetchResult parsedPrice = parser.Parse("test", url);

            parsedPrice.IsSuccess.Should().BeTrue();
            parsedPrice.Price.Should().Be(price);
        }

        [InlineData("http://termoformat.md/ru/immergas_victrix_tera_2428", 19900)]
        [InlineData("https://termoshop.md/shop/cazane/immergas-victrix-tera-24-28/", 16000)]
        [InlineData("http://instalator.md/shop/cazan-cu-condensare-victrix-tera-24-28/", 16915)]
        [InlineData("https://smadshop.md/otoplenie-vodosnabzhenie/immergas-victrix-tera-24-28-gazovyj-kotel.html", 19200)]
        [InlineData("https://instalatii.md/product/centrala-termica-immergas-victrix-tera-24-28/", 17050)]
        [InlineData("https://kazinst.md/produs/centrale/cazane-pe-gaz/cazane-immergas/centrala-immergas-vitrix-tera-24-28/", 19900)]
        [InlineData("https://lianatgrup.md/ro/Cazane/Cazan-pe-gaz/Centrala-termica-IMMERGAS-VICTRIX-TERA-24KW-condens/2755", 19900)]
        [InlineData("https://santehmarket.md/produs/centrala-immergas-victrix-tera-24-28-condens/", 18000)]
        [InlineData("https://maxmart.md/ru/tovary/283317/cazan-immergas-victrix-tera-24-28", 17823)]
        [InlineData("https://magicshop.md/electrocasnice-magic-shopmd/instalatii-termice-si-sanitare/cazane-pe-gaz/cazan-immergas-victrix-tera-24-28-24981-18", 17945)]
        [InlineData("https://ogogo.md/cazan-in-condensare-immergas-victrix-tera-24-28.html", 19900)]
        [InlineData("https://santehproiect.md/108/", 19900)]
        [InlineData("https://nanu.md/ru/gazovye-kotly/47863-kotel-immergas-victrix-tera-2428.html", 17950)]
        [InlineData("https://uniplast.md/ro/437043/", 19890)]
        [InlineData("https://robinet.md/ru/6075374/", 19755)]
        [InlineData("http://www.termodepozit.md/ru/product/centrala-immergas-victrix-tera-2428-1/", 17620)]
        [InlineData("https://teploplus.md/index.php?route=product/product&path=103860_103903&product_id=103912", 19900)]
        [InlineData("http://cazan.md/ro/cazane-in-condensatie-immergas/682-cazan-immergas-in-condensare-victrix-tera-28.html", 0)]
        [InlineData("https://jara.md/ro/5744630/", 19900)]
        [Theory]
        public void ShouldParseExact3(string url, decimal price)
        {
            ISiteParser parser = new SiteParserFactory().GetInstance(url);

            PricesObserver.Models.ProductPriceFetchResult parsedPrice = parser.Parse("test", url);

            parsedPrice.IsSuccess.Should().BeTrue();
            parsedPrice.Price.Should().Be(price);
        }


        [InlineData("https://hamster.md/shop/item/view/80719", 14499)]
        [InlineData("http://baieplus.md/ru/kotly-i-gazovye-kolonki/1569-cazan-immergas-victrix-omnia-25.html", 17500)]
        [InlineData("http://termoformat.md/ru/immergas_victrix_omnia_25", 17500)]
        [InlineData("https://termoshop.md/shop/cazane/immergas-victrix-omnia-25/", 14500)]
        [InlineData("http://instalator.md/shop/centrala-immergas-victrix-omnia-25/", 15750)]
        [InlineData("https://smadshop.md/otoplenie-vodosnabzhenie/immergas-victrix-omnia-25-kw-gazovyj-kotel.html", 17500)]
        [InlineData("https://maxmart.md/ru/tovary/283318/cazan-immergas-victrix-omnia", 17823)]
        [InlineData("https://ogogo.md/cazan-in-condensare-immergas-victrix-omnia-25kw.html", 17500)]
        [InlineData("https://santehproiect.md/109/", 17500)]
        [InlineData("https://bigshop.md/ro/product/cazan-pe-gaz-immergas-victrix-omnia-p93118", 17830)]
        [InlineData("https://robinet.md/ru/6075187/", 16200)]
        [InlineData("http://www.termodepozit.md/ru/product/centrala-immergas-victrix-omnia-25/", 17000)]
        [InlineData("https://teploplus.md/index.php?route=product/product&path=103860_103903&product_id=106476", 17500)]
        [InlineData("http://cazan.md/ro/cazane-in-condensatie-de-perete/906-cazan-immergas-victrix-omnia-25.html", 0)]
        [InlineData("https://jara.md/ro/6074585/", 17500)]
        [Theory]
        public void ShouldParseExact4(string url, decimal price)
        {
            ISiteParser parser = new SiteParserFactory().GetInstance(url);

            PricesObserver.Models.ProductPriceFetchResult parsedPrice = parser.Parse("test", url);

            parsedPrice.IsSuccess.Should().BeTrue();
            parsedPrice.Price.Should().Be(price);
        }

    }
}
