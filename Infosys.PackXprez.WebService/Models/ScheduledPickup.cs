using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infosys.PackXprez.WebService.Models
{
    public class ScheduledPickup
    {
        public int Id { get; set; }
        public string EmailId { get; set; }
        public decimal PickupPinCode { get; set; }
        public decimal DeliveryPinCode { get; set; }
        public string ShipmentType { get; set; }
        public decimal PackageLen { get; set; }
        public decimal PackageBreadth { get; set; }
        public decimal PackageHeight { get; set; }
        public decimal PackageWeight { get; set; }
        public short PackingReq { get; set; }
        public string DeliveryOpt { get; set; }
        public DateTime TimeSlot { get; set; }
        public string PickupAddress { get; set; }
        public string DeliveryAddress { get; set; }
        public short Insurance { get; set; }
        public decimal Amount { get; set; }
        public string Payment { get; set; }
        public long? AwbNumber { get; set; }
        public string Name { get; set; }
    }
}
