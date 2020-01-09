using System;
using System.Collections.Generic;

namespace Infosys.PackXprez.DataAccessLayer.Models
{
    public partial class ReceivePackage
    {
        public ReceivePackage()
        {
            ScheduledPickUp = new HashSet<ScheduledPickUp>();
        }

        public long AwbNumber { get; set; }
        public string CustomerName { get; set; }
        public string FromLocation { get; set; }
        public string ToAddress { get; set; }
        public string UpdatedStatus { get; set; }

        public ICollection<ScheduledPickUp> ScheduledPickUp { get; set; }
    }
}
