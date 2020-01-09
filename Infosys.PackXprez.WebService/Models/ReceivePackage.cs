using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infosys.PackXprez.WebService.Models
{
    public class ReceivePackage
    {
        public long AwbNumber { get; set; }
        public string CustomerName { get; set; }
        public string FromLocation { get; set; }
        public string ToAddress { get; set; }
        public string UpdatedStatus { get; set; }
    }
}
