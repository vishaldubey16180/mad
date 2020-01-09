using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infosys.PackXprez.WebService.Models
{
    public class Customer
    {
        public string CustName { get; set; }
        public string CustEmailId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public decimal ContactNo { get; set; }
        public string BuildingNo { get; set; }
        public string StreetNo { get; set; }
        public string Locality { get; set; }
        public decimal PinCode { get; set; }
    }
}

