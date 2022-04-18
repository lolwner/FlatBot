using FlatBot.Application.Scrapers;
using FlatBot.Domain.Entities;
using Moq;

namespace FlatBot.Application.UnitTests.Helpers
{
    public static class OLXScraperHelper
    {
        private static List<RawOlxOffer> data = new List<RawOlxOffer>
            {
                new RawOlxOffer()
                {
                    Date = "Вчора",
                    Description = "Description1",
                    Image = "ImgSrc1",
                    Link =  "Link1",
                    Price = "1.0",
                },
                new RawOlxOffer()
                {
                    Date = "Сьогодні",
                    Description = "Description2",
                    Image = "ImgSrc2",
                    Link =  "Link2",
                    Price = "2.0",
                }
            };

        public static List<RawOlxOffer> GetData()
        {
            return data;
        }

        public static Mock<IOLXScraper> GetOLXScraperMock()
        {
            var repository = new Mock<IOLXScraper>();

            return repository;
        }
    }
}
