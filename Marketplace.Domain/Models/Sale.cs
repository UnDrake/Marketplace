using FitnessArchitecture.Domain.Enum;

namespace Marketplace.Domain.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public DateTime CreateDt { get; set; }
        public DateTime FinishDt { get; set; }
        public decimal Price { get; set; }
        public MarketStatus Status { get; set; }
        public string Seller { get; set; }
        public string Buyer { get; set; }
    }
}