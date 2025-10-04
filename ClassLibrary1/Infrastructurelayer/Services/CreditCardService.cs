using ApplicationLayer.Interfaces;
using ApplicationLayer.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DomainLayer.Domain.Entites;
using InfrastructureLayer.Infrastructurelayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace InfrastructureLayer.Infrastructurelayer.Services
{
    public class CreditCardService : ICreditCardService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CreditCardService(AppDbContext context,IMapper _mapper)
        {
            _context = context;
            this._mapper = _mapper;

        }
        public async Task AddAsync(CreditCardViewModel model)
        {
            var entity = _mapper.Map<CreditCard>(model);
            entity.Id = Guid.NewGuid().GetHashCode();
            entity.CreatedDate = DateTime.UtcNow;

           await _context.CreditCards.AddAsync(entity);
           await _context.SaveChangesAsync();

        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CreditCardViewModel>> GetAllAsync()
        {
            return await _context.CreditCards
                .AsNoTracking()
                .ProjectTo<CreditCardViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }


        public async  Task<CreditCardViewModel> GetByIdAsync(int id)
        {

          var entity = _context.CreditCards
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
            if (entity == null)
                return null;
            return _mapper.Map<CreditCardViewModel>(await entity);
        }

        public async Task<bool> UpdateAsync(int id, CreditCardViewModel model)
        {
            var entity = _context.CreditCards
                .FirstOrDefault(x => x.Id == id);
                if (entity == null) return false ;
            else
            {
                _mapper.Map(model, entity);
                entity.UpdatedDate = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                return true;

            }
             
        }
    }
}
