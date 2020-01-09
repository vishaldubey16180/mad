using System;
using System.Collections.Generic;

namespace Infosys.PackXprez.DataAccessLayer.Models
{
    public partial class PickDelRepresentatives
    {
        public int RepresentativeId { get; set; }
        public string TaskAssign { get; set; }
        public int? TaskId { get; set; }
        public string PickUpAdd { get; set; }
        public string DeliveryAdd { get; set; }
        public long? Awbnumber { get; set; }
    }
}
