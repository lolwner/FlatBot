using FlatBot.Domain.Entities;

namespace FlatBot.Application.Mappers
{
    public interface IOLXMapper
    {
        List<OlxOfferEntity> Map(List<RawOlxOffer> rawOffer);
    }
}
