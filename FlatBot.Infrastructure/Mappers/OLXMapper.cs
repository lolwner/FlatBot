using FlatBot.Application.Mappers;
using FlatBot.Domain.Constants;
using FlatBot.Domain.Entities;
using System.Text.RegularExpressions;

namespace FlatBot.Infrastructure.Mappers
{
    public class OLXMapper : IOLXMapper
    {
        public List<OlxOfferEntity> Map(List<RawOlxOffer> rawOffers)
        {
            var mappedOffers = new List<OlxOfferEntity>();
            var batchId = Guid.NewGuid().ToString();
            var creationDateUTC = DateTime.UtcNow;

            foreach (var rawOffer in rawOffers)
            {
                OlxOfferEntity olxOfferEntity = new OlxOfferEntity();
                if (rawOffer.Date.Contains(ContentConstants.OLXTodayString))
                {
                    var stringTime = rawOffer.Date.Split(ContentConstants.OLXTodayString, StringSplitOptions.TrimEntries).Last();
                    var hourSuccess = Int32.TryParse(stringTime.Split(":").First(), out int hour);
                    var minuteSuccess = Int32.TryParse(stringTime.Split(":").Last(), out int minute);

                    if (hourSuccess && minuteSuccess)
                    {
                        var currentDate = DateTime.Now;
                        var date = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, hour, minute, 0);
                        olxOfferEntity.UTCDate = date.ToUniversalTime();
                    }
                }

                //TODO: add currency

                var priceNoSpaces = string.Concat(rawOffer.Price.Where(c => !char.IsWhiteSpace(c)));
                var priceNumber = Regex.Match(priceNoSpaces, @"\d+").Value;
                var priceSuccess = double.TryParse(priceNumber, out double price);

                if (priceSuccess)
                {
                    olxOfferEntity.Price = price;
                }

                olxOfferEntity.Description = rawOffer.Description;
                olxOfferEntity.Image = rawOffer.Image;
                olxOfferEntity.Link = rawOffer.Link;
                olxOfferEntity.BatchId = batchId;
                olxOfferEntity.CreattionDateUTC = creationDateUTC;

                mappedOffers.Add(olxOfferEntity);
            }

            return mappedOffers;
        }
    }
}
