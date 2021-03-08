﻿using PricesObserver.SiteParsers.Sites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricesObserver.SiteParsers
{
    public interface ISiteParserFactory
    {
        ISiteParser GetInstance(string url);
    }

    public class SiteParserFactory : ISiteParserFactory
    {
        public ISiteParser GetInstance(string url)
        {
            switch (url)
            {
                case "https://hamster.md/shop/item/view/24857":
                    return new HamsterMdParser();
                case "http://instalator.md/shop/centrala-termica-immergas-eolo-star-24/":
                    return new InstalatorMdParser();
                case "http://baieplus.md/ru/kotly-i-gazovye-kolonki/18-cazan-immergas-eolo-star.html":
                    return new BaiePlusParser();
                case "http://cazan.md/ro/cazan-immergas/11-cazan-immergas-eolo-star-24.html":
                    return new CazanMdParser();
                case "http://termoformat.md/ru/immergas_eolo_star_24_3e":
                    return new TermoformatMdParser();
                case "https://smadshop.md/otoplenie-vodosnabzhenie/kotiol-immergas-eolo-star.html":
                    return new SmadShopMdParser();
                case "https://instalatii.md/product/cazan-immergas-eolo-star-24/":
                    return new InstalatiiMdParser();
                case "https://supraten.md/centrala-termica-pe-gaz-eolo-star-24-277351-ro":
                    return new SupratedMdParser();
                case "https://santehmarket.md/produs/centrala-immergas-eolo-star-24-kw/":
                    return new SantehMarketMdParser();
                case "https://maxmart.md/ru/tovary/283313/cazan-immergas-eolo-star-24-kw":
                    return new MaxmartMdParser();
                case "https://magicshop.md/electrocasnice-magic-shopmd/instalatii-termice-si-sanitare/cazane-pe-gaz/cazan-immergas-eolo-star-24-kw-0018-18":
                    return new MagicShopParser();
                case "https://ogogo.md/cazan-immergas-eolo-star.html":
                    return new OgogoMdParser();
                case "https://econstruct.md/ro/5871563/":
                    return new EcoconstructParser();
                case "https://bigshop.md/ro/product/immergas-eolo-star-24-3e-p18877":
                    return new BigshopMdParser();
                case "https://uniplast.md/ro/437044/":
                    return new UniplastMdParser();
                case "https://meserias.md/ro/otoplenie-i-vodosnabjenie/kotly-otopleniya/gazovyj-kotel-immergas-eolo-star-24-kw":
                    return new MeseriasMdParser();
                case "https://robinet.md/ru/6075423/":
                    return new RobinetMdParser();
                case "http://www.termodepozit.md/ru/product/centrala-immergas-eolo-star-24-kw/":
                    return new TermoDepozitParser();
                case "https://teploplus.md/index.php?route=product/product&path=103860_103903&product_id=103908":
                    return new TeploplusParser();
                case "https://jara.md/ro/5744637/":
                    return new JaraMdParser();
                default:
                    throw new NotImplementedException($"A parser for the page {url} does not exist");
            }
        }
    }
}
