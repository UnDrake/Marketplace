using Marketplace.DAL.Interfaces;
using Marketplace.Domain.Models;

namespace Marketplace.DAL.Repositories
{
    public class ItemRepository : IBaseRepository<Item>
    {
        private readonly AppDbContext appDbContext;
        public ItemRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        public async Task Create(Item entity)
        {
            await appDbContext.AddAsync(entity);
            await appDbContext.SaveChangesAsync();
        }

        public async Task Delete(Item entity)
        {
            appDbContext.Remove(entity);
            await appDbContext.SaveChangesAsync();
        }

        public async Task<Item> Update(Item entity)
        {
            appDbContext.Update(entity);
            await appDbContext.SaveChangesAsync();
            return entity;
        }

        public IQueryable<Item> GetAll()
        {
            return appDbContext.Items;

        }
    }
}
