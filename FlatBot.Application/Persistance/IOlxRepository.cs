using FlatBot.Domain.Entities;

namespace FlatBot.Application.Persistance
{
    public interface IOlxRepository
    {
        Task<List<OlxOfferEntity>> GetAsync();
        Task<OlxOfferEntity?> GetAsync(string id);
        Task CreateAsync(OlxOfferEntity newBook);
        Task CreateAsync(List<OlxOfferEntity> newBooks);
        Task UpdateAsync(string id, OlxOfferEntity updatedBook);
        Task RemoveAsync(string id);
    }
}
