namespace FlatBot.Domain.Entities
{
    public class CitySource
    {
        public string City { get; set; }
        public List<int> Sources { get; set; }
        public Dictionary<string, List<int>> CitySources { get; set; }
    }
}
