using System;
using System.Collections.Generic;

namespace Infosys.PackXprez.DataAccessLayer.Models
{
    public partial class BranchOfficer
    {
        public int Boid { get; set; }
        public string Boname { get; set; }
        public string BoemailId { get; set; }
        public string Password { get; set; }
        public string Location { get; set; }
    }
}
