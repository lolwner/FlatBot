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
        private readonly IOLXLinkBuilderService _oLXLinkBuilderService;
        private readonly ILogger<OLXService> _logger;

        public OLXService(IOlxRepository olxRepository,
            IOLXScraper oLXScraper,
            IOLXMapper oLXMapper, IOLXLinkBuilderService oLXLinkBuilderService,
            ILogger<OLXService> logger)
        {
            _olxRepository = olxRepository;
            _oLXScraper = oLXScraper;
            _oLXMapper = oLXMapper;
            _oLXLinkBuilderService = oLXLinkBuilderService;
            _logger = logger;
        }

        public async Task<List<OlxOfferEntity>> GetOLXData(OlxSearchParameters olxSearchParameters)
        {
            string link = _oLXLinkBuilderService.GetOLXLink(olxSearchParameters);

            List<RawOlxOffer> data = await _oLXScraper.ScrapeOLXAsync(link);
            List<RawOlxOffer> todayOffersList = data?.Where(x => x.Date.Contains(ContentConstants.OLXTodayString)).ToList();

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
