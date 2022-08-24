namespace FlatBot.Domain.Entities
{
    public class BaseOfferEntity
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Currency { get; set; }
        public decimal Price { get; set; }
        public DateTime CreattionDateUTC { get; set; }
        public string BatchId { get; set; }
    }
}
