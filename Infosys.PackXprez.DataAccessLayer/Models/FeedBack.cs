using System;
using System.Collections.Generic;

namespace Infosys.PackXprez.DataAccessLayer.Models
{
    public partial class FeedBack
    {
        public string EmailId { get; set; }
        public string FeedbackType { get; set; }
        public string Comments { get; set; }

        public Customer Email { get; set; }
    }
}
