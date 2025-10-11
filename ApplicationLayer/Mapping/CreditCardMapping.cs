using ApplicationLayer.ViewModels;
using DomainLayer.Domain.Entites;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Mapping
{
    public class CreditCardMapping : IRegister
    {
        //Entity => ViewModel
        public void Register(TypeAdapterConfig config)
        {
            // Entity -> ViewModel
            config.NewConfig<CreditCard, CreditCardViewModel>()
                  .Map(dest => dest.BillingCycle,
                       src => src.BillingCycleStart.HasValue && src.BillingCycleEnd.HasValue
                              ? $"{src.BillingCycleStart:dd.MM.yyyy} - {src.BillingCycleEnd:dd.MM.yyyy}"
                              : string.Empty)
                  // Benefits artık direkt List<string> olduğu için ekstra işlem yok
                  .Map(dest => dest.Benefits, src => src.Benefits);

            // ViewModel -> Entity
            config.NewConfig<CreditCardViewModel, CreditCard>()
                  .Map(dest => dest.BillingCycleStart,
                       src => ParseStartDate(src.BillingCycle))
                  .Map(dest => dest.BillingCycleEnd,
                       src => ParseEndDate(src.BillingCycle))
                  // Benefits yine direkt List<string>
                  .Map(dest => dest.Benefits, src => src.Benefits);
        }

        private DateTime? ParseStartDate(string? billingCycle)
        {
            if (string.IsNullOrWhiteSpace(billingCycle)) return null;
            var parts = billingCycle.Split('-');
            return DateTime.TryParse(parts[0].Trim(), out var date) ? date : null;
        }

        private DateTime? ParseEndDate(string? billingCycle)
        {
            if (string.IsNullOrWhiteSpace(billingCycle)) return null;
            var parts = billingCycle.Split('-');
            return parts.Length > 1 && DateTime.TryParse(parts[1].Trim(), out var date) ? date : null;
        }


    }
}
