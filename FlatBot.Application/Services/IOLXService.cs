using FlatBot.Domain.Entities;

namespace FlatBot.Application.Services
{
    public interface IOLXService
    {
        Task<List<OlxOfferEntity>> FetchOLXData(OlxSearchParameters olxSearchParameters);
        Task<List<OlxOfferEntity>> GetOLXData();
    }
}
