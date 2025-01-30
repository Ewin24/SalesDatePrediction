namespace API.Dtos.Client
{
    public class ClientOrderDto
    {
        public int OrderId { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; } // Nullable porque shippeddate puede ser NULL
        public string ShipName { get; set; }
    }
}