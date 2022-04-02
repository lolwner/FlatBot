﻿using FlatBot.Application.Mappers;
using FlatBot.Application.Persistance;
using FlatBot.Application.Scrapers;
using FlatBot.Application.Services;

namespace FlatBot.Infrastructure.Services
{
    public class OLXService : IOLXService
    {
        private readonly IOlxRepository _olxRepository;
        private readonly IOLXScraper _oLXScraper;
        private readonly IOLXMapper _oLXMapper;


        public OLXService(IOlxRepository olxRepository, IOLXScraper oLXScraper, IOLXMapper oLXMapper)
        {
            _olxRepository = olxRepository;
            _oLXScraper = oLXScraper;
            _oLXMapper = oLXMapper;
        }

        public async Task TestFunctionality()
        {
            var data = await _oLXScraper.ScrapeOLX();
            var todayOffersList = data?.Where(x => x.Date.Contains("Сьогодні")).ToList();

            if (todayOffersList is null)
            {
                return;
            }

            var offers = _oLXMapper.Map(todayOffersList);
            await _olxRepository.CreateAsync(offers);
        }
    }
}
