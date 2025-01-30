namespace API.Dtos.Order
{
    public class OrderDto
    {
        public int EmpId { get; set; }               // Employee ID
        public int ShipperId { get; set; }           // Shipper ID
        public string ShipName { get; set; }         // Ship Name
        public string ShipAddress { get; set; }      // Ship Address
        public string ShipCity { get; set; }         // Ship City
        public DateTime OrderDate { get; set; }      // Order Date
        public DateTime RequiredDate { get; set; }   // Required Date
        public DateTime? ShippedDate { get; set; }   // Shipped Date (puede ser NULL)
        public decimal Freight { get; set; }         // Freight
        public string ShipCountry { get; set; }      // Ship Country
        public int ProductId { get; set; }           // Product ID para OrderDetails
        public decimal UnitPrice { get; set; }       // Unit Price para OrderDetails
        public short Qty { get; set; }               // Quantity para OrderDetails
        public decimal Discount { get; set; }        // Discount para OrderDetails
    }
}