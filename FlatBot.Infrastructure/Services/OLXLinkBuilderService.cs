using Cyrillic.Convert;
using FlatBot.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatBot.Infrastructure.Services
{
    public class OLXLinkBuilderService
    {
        public OLXLinkBuilderService()
        {

        }

        public void GetOLXLink(OlxSearchParameters olxSearchParameters)
        {
            var conversion = new Conversion();
            var a = "Київ";
            var b = "Киев";
            var latin = a.ToUkrainianLatin();
            var latin2 = b.ToUkrainianLatin();
            var latin3 = a.ToRussianLatin();
            var latin4 = b.ToRussianLatin();
            var link = "https://www.olx.ua/uk/nedvizhimost/kvartiry/dolgosrochnaya-arenda-kvartir/kiev/";


        }
    }
}
