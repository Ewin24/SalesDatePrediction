using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class CreateOrder
    {
        [Required(ErrorMessage = "CustomerId is required")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Employee is required")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Shipper is required")]
        public int ShipperId { get; set; }

        // Datos de envío
        [Required(ErrorMessage = "Ship Name is required")]
        public string ShipName { get; set; }

        [Required(ErrorMessage = "Ship Address is required")]
        public string ShipAddress { get; set; }

        [Required(ErrorMessage = "Ship City is required")]
        public string ShipCity { get; set; }

        [Required(ErrorMessage = "Ship Country is required")]
        public string ShipCountry { get; set; }

        // Fechas
        [Required(ErrorMessage = "Order Date is required")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Required Date is required")]
        public DateTime RequiredDate { get; set; }

        public DateTime? ShippedDate { get; set; } // Opcional

        [Range(0, double.MaxValue, ErrorMessage = "Freight must be a positive value")]
        public decimal Freight { get; set; }
        public short Quantity { get; set; }
        public decimal Discount { get; set; }
        public int ProductId { get; set; }
    }
}