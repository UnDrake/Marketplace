using Marketplace.DAL.Interfaces;
using Marketplace.Domain.Models;
using System;

namespace Marketplace.DAL.Repositories
{
    public class SaleRepository : IBaseRepository<Sale>
    {
        private readonly AppDbContext appDbContext;
        public SaleRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        public async Task Create(Sale entity)
        {
            await appDbContext.AddAsync(entity);
            await appDbContext.SaveChangesAsync();
        }

        public async Task Delete(Sale entity)
        {
            appDbContext.Remove(entity);
            await appDbContext.SaveChangesAsync();
        }

        public async Task<Sale> Update(Sale entity)
        {
            appDbContext.Update(entity);
            await appDbContext.SaveChangesAsync();
            return entity;
        }

        public IQueryable<Sale> GetAll()
        {
            return appDbContext.Sales;
        }
    }
}
