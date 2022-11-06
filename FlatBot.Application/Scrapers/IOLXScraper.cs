using FlatBot.Domain.Entities;

namespace FlatBot.Application.Scrapers
{
    public interface IOLXScraper
    {
        Task<List<RawOlxOffer>> ScrapeOLXAsync(string link);
    }
}
