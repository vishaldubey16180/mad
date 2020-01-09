using System;
using System.Collections.Generic;

namespace Infosys.PackXprez.DataAccessLayer.Models
{
    public partial class CardDetails
    {
        public CardDetails()
        {
            SavedCards = new HashSet<SavedCards>();
        }

        public decimal CardNumber { get; set; }
        public string NameOnCard { get; set; }
        public string CardType { get; set; }
        public decimal Cvvnumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal? Balance { get; set; }

        public ICollection<SavedCards> SavedCards { get; set; }
    }
}
