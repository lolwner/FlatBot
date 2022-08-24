using Newtonsoft.Json;

namespace FlatBot.Infrastructure.Models
{
    public class CityViewModel
    {
        [JsonProperty]
        public string Country { get; set; }
        [JsonProperty]
        public string Name { get; set; }
    }
}
