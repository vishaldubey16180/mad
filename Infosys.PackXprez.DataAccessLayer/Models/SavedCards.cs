using System;
using System.Collections.Generic;

namespace Infosys.PackXprez.DataAccessLayer.Models
{
    public partial class SavedCards
    {
        public string EmailId { get; set; }
        public decimal CardNumber { get; set; }

        public CardDetails CardNumberNavigation { get; set; }
    }
}
