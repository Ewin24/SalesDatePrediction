namespace Domain.Entities
{
    public class CustomerOrderPrediction
    {
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public DateTime? LastOrderDate { get; set; }
        public DateTime? NextPredictedOrderDate { get; set; }
    }
}