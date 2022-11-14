namespace FlatBot.Domain.Entities
{
    public class OlxOfferEntity : BaseOfferEntity
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public DateTime UTCDate { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }
    }
}
