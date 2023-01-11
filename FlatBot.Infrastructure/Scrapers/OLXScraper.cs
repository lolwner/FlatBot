using FlatBot.Application.Scrapers;
using FlatBot.Domain.Entities;
using HtmlAgilityPack;

namespace FlatBot.Infrastructure.Scrapers
{
    internal class OLXScraper : IOLXScraper
    {
        public async Task<List<RawOlxOffer>> ScrapeOLXAsync(string link)
        {
            link = "https://www.olx.ua/uk/nedvizhimost/kvartiry/dolgosrochnaya-arenda-kvartir/kiev/";
            //TODO: link check
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = await web.LoadFromWebAsync(link);

            var offersNode = doc.DocumentNode.SelectNodes("//table[@class='fixed offers breakword offers--top redesigned']/tbody").FirstOrDefault();

            if (offersNode is null)
            {
                //TODO: add markup exception
                return null;
            }

            var dates = offersNode.SelectNodes("//td[@class='bottom-cell']/div/p/small[2]/span")
                .Select(x => x.InnerText).ToList();
            var prices = offersNode.SelectNodes("//p[@class='price']/strong")
                .Select(x => x.InnerText).ToList();
            var descriptions = offersNode.SelectNodes("//a[@data-cy='listing-ad-title']/strong")
                .Select(x => x.InnerText).ToList();
            var images = offersNode.SelectNodes("//img[@class='fleft']")
                .Select(x => x.Attributes["src"].Value).ToList();
            var links = offersNode.SelectNodes("//a[@data-cy='listing-ad-title']")
                .Select(x => x.Attributes["href"].Value).ToList();

            var offers = new List<RawOlxOffer>();
            int[] items = { dates.Count, prices.Count, descriptions.Count, images.Count, links.Count };
            var count = items.Min();

            for (int i = 0; i < count; i++)
            {
                offers.Add(new RawOlxOffer
                {
                    Date = dates[i],
                    Price = prices[i],
                    Description = descriptions[i],
                    Image = images[i],
                    Link = links[i]
                });
            }

            return offers;
        }
    }
}
