using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Domain.Entites
{
    public class CreditCard
    {
        public int Id { get; set; }
        public string? CardName { get; set; }
        public string? BankName { get; set; }
        public string? CardType { get; set; } // Visa, MasterCard
        public decimal? Limit { get; set; }
        public decimal? CurrentBalance { get; set; }

       
        public DateTime? BillingCycleStart { get; set; }
        public DateTime? BillingCycleEnd { get; set; }
        public List<string>? Benefits { get; set; }


        

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
