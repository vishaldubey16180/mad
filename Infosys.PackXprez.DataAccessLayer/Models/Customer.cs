using System;
using System.Collections.Generic;

namespace Infosys.PackXprez.DataAccessLayer.Models
{
    public partial class Customer
    {
        public Customer()
        {
            FeedBack = new HashSet<FeedBack>();
            Orders = new HashSet<Orders>();
            ScheduledPickUp = new HashSet<ScheduledPickUp>();
        }

        public string CustName { get; set; }
        public string CustEmailId { get; set; }
        public string Password { get; set; }
        public decimal ContactNo { get; set; }
        public string BuildingNo { get; set; }
        public string StreetNo { get; set; }
        public string Locality { get; set; }
        public decimal PinCode { get; set; }

        public ICollection<FeedBack> FeedBack { get; set; }
        public ICollection<Orders> Orders { get; set; }
        public ICollection<ScheduledPickUp> ScheduledPickUp { get; set; }
    }
}
