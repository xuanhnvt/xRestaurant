using System;

namespace Shipping.API.Data.Entities
{
    public class Shipment
    {
        public Guid OrderId { get; set; }
        public long ShipmentNo { get; set; }
        public string TrackingNumber { get; set; }
        public decimal? TotalWeight { get; set; }
        public DateTime? ShippedDateUtc { get; set; }
        public DateTime? DeliveryDateUtc { get; set; }
        public string AdminComment { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
