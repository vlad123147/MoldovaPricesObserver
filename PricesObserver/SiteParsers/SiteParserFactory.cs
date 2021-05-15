using PricesObserver.SiteParsers.Sites;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PricesObserver.SiteParsers
{
    public interface ISiteParserFactory
    {
        ISiteParser GetInstance(string url);
    }

    public class SiteParserFactory : ISiteParserFactory
    {
		public SiteParserFactory()
		{
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en", false);
        }
        public ISiteParser GetInstance(string url)
        {
            var host = new Uri(url).Host;

            switch (host)
            {
                case "hamster.md":
                    return new HamsterMdParser();
                case "instalator.md":
                    return new InstalatorMdParser();
                case "baieplus.md":
                    return new BaiePlusParser();
                case "cazan.md":
                    return new CazanMdParser();
                case "termoformat.md":
                    return new TermoformatMdParser();
                case "smadshop.md":
                    return new SmadShopMdParser();
                case "instalatii.md":
                    return new InstalatiiMdParser();
                case "supraten.md":
                    return new SupratedMdParser();
                case "santehmarket.md":
                    return new SantehMarketMdParser();
                case "maxmart.md":
                    return new MaxmartMdParser();
                case "magicshop.md":
                    return new MagicShopParser();
                case "ogogo.md":
                    return new OgogoMdParser();
                case "econstruct.md":
                    return new EcoconstructParser();
                case "kazinst.md":
                    return new KazinstMdParser();
                case "lianatgrup.md":
                    return new LianatGrupMdParser();
                case "nanu.md":
                    return new NanuMdParser();
                case "bigshop.md":
                    return new BigshopMdParser();
                case "uniplast.md":
                    return new UniplastMdParser();
                case "meserias.md":
                    return new MeseriasMdParser();
                case "robinet.md":
                    return new RobinetMdParser();
                case "www.termodepozit.md":
                    return new TermoDepozitParser();
                case "teploplus.md":
                    return new TeploplusParser();
                case "jara.md":
                    return new JaraMdParser();
                case "santehproiect.md":
                    return new SantehProiectMdParser();
                case "termoshop.md":
                    return new TermoshopMdParser();
                default:
                    throw new NotImplementedException($"A parser for the page {url} does not exist");
            }

            //switch (url)
            //{
            //    case "https://hamster.md/shop/item/view/24857":
            //        return new HamsterMdParser();
            //    case "http://instalator.md/shop/centrala-termica-immergas-eolo-star-24/":
            //    case "http://instalator.md/shop/cazan-immergas-eolo-mythos-24-kw/":
            //        return new InstalatorMdParser();
            //    case "http://baieplus.md/ru/kotly-i-gazovye-kolonki/18-cazan-immergas-eolo-star.html":
            //    case "http://baieplus.md/ru/kotly-i-gazovye-kolonki/651-cazan-immergas-eolo-mythos.html":
            //        return new BaiePlusParser();
            //    case "http://cazan.md/ro/cazan-immergas/11-cazan-immergas-eolo-star-24.html":
            //        return new CazanMdParser();
            //    case "http://termoformat.md/ru/immergas_eolo_star_24_3e":
            //        return new TermoformatMdParser();
            //    case "https://smadshop.md/otoplenie-vodosnabzhenie/kotiol-immergas-eolo-star.html":
            //        return new SmadShopMdParser();
            //    case "https://instalatii.md/product/cazan-immergas-eolo-star-24/":
            //        return new InstalatiiMdParser();
            //    case "https://supraten.md/centrala-termica-pe-gaz-eolo-star-24-277351-ro":
            //        return new SupratedMdParser();
            //    case "https://santehmarket.md/produs/centrala-immergas-eolo-star-24-kw/":
            //        return new SantehMarketMdParser();
            //    case "https://maxmart.md/ru/tovary/283313/cazan-immergas-eolo-star-24-kw":
            //        return new MaxmartMdParser();
            //    case "https://magicshop.md/electrocasnice-magic-shopmd/instalatii-termice-si-sanitare/cazane-pe-gaz/cazan-immergas-eolo-star-24-kw-0018-18":
            //        return new MagicShopParser();
            //    case "https://ogogo.md/cazan-immergas-eolo-star.html":
            //        return new OgogoMdParser();
            //    case "https://econstruct.md/ro/5871563/":
            //        return new EcoconstructParser();

            //    case "https://bigshop.md/ro/product/immergas-eolo-star-24-3e-p18877":
            //    case "https://bigshop.md/ro/product/immergas-eolo-mytos-24-kw-p18879":
            //        return new BigshopMdParser();
            //    case "https://uniplast.md/ro/437044/":
            //        return new UniplastMdParser();
            //    case "https://meserias.md/ro/otoplenie-i-vodosnabjenie/kotly-otopleniya/gazovyj-kotel-immergas-eolo-star-24-kw":
            //        return new MeseriasMdParser();
            //    case "https://robinet.md/ru/6075423/":
            //        return new RobinetMdParser();
            //    case "http://www.termodepozit.md/ru/product/centrala-immergas-eolo-mythos-24-kw-1/":
            //    case "http://www.termodepozit.md/ru/product/centrala-immergas-eolo-star-24-kw/":
            //        return new TermoDepozitParser();
            //    case "https://teploplus.md/index.php?route=product/product&path=103860_103903&product_id=103908":
            //        return new TeploplusParser();
            //    case "https://jara.md/ro/5744637/":
            //        return new JaraMdParser();
            //    default:
            //        throw new NotImplementedException($"A parser for the page {url} does not exist");
            //}
        }
    }
}
