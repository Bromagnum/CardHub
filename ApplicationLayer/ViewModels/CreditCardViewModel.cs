using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.ViewModels
{
    public class CreditCardViewModel
    {
        public int Id { get; set; }
        public string? CardName { get; set; }
        public string? BankName { get; set; }
        public string? CardType { get; set; }
        public decimal? Limit { get; set; }
        public decimal? CurrentBalance { get; set; }
        public string? BillingCycle { get; set; } // formatted string
        public List<string>? Benefits { get; set; }



    }
}
