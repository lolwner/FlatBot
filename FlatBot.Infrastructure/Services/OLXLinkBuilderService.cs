using Cyrillic.Convert;
using FlatBot.Application.Services;
using FlatBot.Domain.Entities;
using System.Text;

namespace FlatBot.Infrastructure.Services
{
    public class OLXLinkBuilderService : IOLXLinkBuilderService
    {
        public string GetOLXLink(OlxSearchParameters olxSearchParameters)
        {
            //TODO: add ability to store and manage default search parameters
            if (olxSearchParameters is null)
            {
                return GetDefaultSearchLink();
            }

            //https://www.olx.ua/d/uk/
            const string domain = "https://www.olx.ua/uk/";
            const string searchStringBase = "nedvizhimost/kvartiry/dolgosrochnaya-arenda-kvartir/";
            const string currencyBase = "/?currency=UAH";
            const string minPrice = "&search%5Bfilter_float_price:from%5D=";
            const string maxPrice = "&search%5Bfilter_float_price:to%5D=";

            StringBuilder baseLink = new StringBuilder(domain);

            baseLink.Append(searchStringBase);
            //TODO: add translation service for cases of unknown language
            baseLink.Append(olxSearchParameters.City.ToRussianLatin());

            //TODO: add currency to search
            if (olxSearchParameters.MinPrice.HasValue || olxSearchParameters.MaxPrice.HasValue)
            {
                baseLink.Append(currencyBase);
            }

            if (olxSearchParameters.MinPrice.HasValue)
            {
                baseLink.Append(minPrice);
                baseLink.Append(olxSearchParameters.MinPrice);
            }

            if (olxSearchParameters.MaxPrice.HasValue)
            {
                baseLink.Append(maxPrice);
                baseLink.Append(olxSearchParameters.MaxPrice);
            }

            return baseLink.ToString();
        }

        private string GetDefaultSearchLink()
        {
            const string link = "https://www.olx.ua/d/uk/nedvizhimost/kvartiry/dolgosrochnaya-arenda-kvartir/kiev/";

            return link;
        }
    }
}
