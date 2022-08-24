namespace FlatBot.Domain.Entities
{
    public class CitySource
    {
        public Guid CityId { get; set; }
        public string City { get; set; }
        public List<int> Sources { get; set; }
    }
}
