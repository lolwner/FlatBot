namespace FlatBot.Application.Persistance
{
    public interface ICitiesManagementRepository
    {
        public Task AddCity(string city);
    }
}
