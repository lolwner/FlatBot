using FlatBot.Domain.Entities;

namespace FlatBot.Application.Services
{
    public interface IOLXLinkBuilderService
    {
        public string GetOLXLink(OlxSearchParameters olxSearchParameters);
    }
}
