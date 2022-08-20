using FlatBot.Domain.Entities;

namespace FlatBot.Application.Services
{
    public interface IOLXService
    {
        Task<List<OlxOfferEntity>> GetOLXData(OlxSearchParameters olxSearchParameters);
    }
}
