using FlatBot.Application.Mappers;
using FlatBot.Application.Persistance;
using FlatBot.Application.Scrapers;
using FlatBot.Application.Services;
using FlatBot.Domain.Constants;
using FlatBot.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace FlatBot.Infrastructure.Services
{
    public class OLXService : IOLXService
    {
        private readonly IOlxRepository _olxRepository;
        private readonly IOLXScraper _oLXScraper;
        private readonly IOLXMapper _oLXMapper;
        private readonly ILogger<OLXService> _logger;

        public OLXService(IOlxRepository olxRepository, IOLXScraper oLXScraper, IOLXMapper oLXMapper, ILogger<OLXService> logger)
        {
            _olxRepository = olxRepository;
            _oLXScraper = oLXScraper;
            _oLXMapper = oLXMapper;
            _logger = logger;
        }

        public async Task<List<OlxOfferEntity>> GetOLXData(OlxSearchParameters olxSearchParameters)
        {
            OLXLinkBuilderService a = new OLXLinkBuilderService();
            a.GetOLXLink(new OlxSearchParameters());
            _logger.LogInformation("test");
            //TODO: add link builder
            var data = await _oLXScraper.ScrapeOLXAsync("");
            var todayOffersList = data?.Where(x => x.Date.Contains(ContentConstants.OLXTodayString)).ToList();

            if (todayOffersList is not null)
            {
                var offers = _oLXMapper.Map(todayOffersList);
                await _olxRepository.CreateAsync(offers);

                return offers;
            }

            return null;
        }
    }
}
