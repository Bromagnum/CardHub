using ApplicationLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Interfaces
{
    public interface ICreditCardService
    {
        Task<List<CreditCardViewModel>> GetAllAsync();
        Task<CreditCardViewModel> GetByIdAsync(int id);
        Task AddAsync(CreditCardViewModel model);
        Task<bool> UpdateAsync(int id, CreditCardViewModel model);
        Task DeleteAsync(int id);


    }
}
