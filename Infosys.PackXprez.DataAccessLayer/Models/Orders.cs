using System;
using System.Collections.Generic;

namespace Infosys.PackXprez.DataAccessLayer.Models
{
    public partial class Orders
    {
        public int OrderNo { get; set; }
        public long? AwbNumber { get; set; }
        public string EmailId { get; set; }
        public string DeliveryAddress { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }

        public Customer Email { get; set; }
    }
}
