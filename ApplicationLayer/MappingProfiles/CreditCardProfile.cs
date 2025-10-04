using ApplicationLayer.ViewModels;
using AutoMapper;
using DomainLayer.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApplicationLayer.MappingProfiles
{
    public class CreditCardProfile : Profile
    {
        public CreditCardProfile()
        {
            CreateMap<CreditCard, CreditCardViewModel>();
            CreateMap<CreditCardViewModel, CreditCard>();

        }

    }
}
