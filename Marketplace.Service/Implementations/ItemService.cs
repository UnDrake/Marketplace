using FitnessArchitecture.Domain.Enum;
using FitnessArchitecture.Domain.Response;
using Marketplace.DAL.Interfaces;
using Marketplace.Domain.Models;
using Marketplace.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Service.Implementations
{
    public class ItemService : IItemService
    {
        private readonly IBaseRepository<Item> itemRepository;
        public ItemService(IBaseRepository<Item> itemRepository)
        {
            this.itemRepository = itemRepository;
        }


        public async Task<IBaseResponse<Item>> GetItemById(int Id)
        {
            try
            {
                var Item = await itemRepository.GetAll().FirstOrDefaultAsync(i => i.Id == Id);

                if (Item == null)
                {
                    return new BaseResponse<Item>()
                    {
                        Description = "Item not found",
                        StatusCode = System.Net.HttpStatusCode.NoContent,
                    };
                }

                return new BaseResponse<Item>()
                {
                    Data = Item,
                    Description = "Item successfully found",
                    StatusCode = System.Net.HttpStatusCode.OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Item>()
                {
                    Description = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                };
            }
        }

        public async Task<IBaseResponse<Item>> GetItemByName(string Name)
        {
            try
            {
                var Item = await itemRepository.GetAll().FirstOrDefaultAsync(i => i.Name == Name);

                if (Item == null)
                {
                    return new BaseResponse<Item>()
                    {
                        Description = "Item not found",
                        StatusCode = System.Net.HttpStatusCode.NoContent,
                    };
                }

                return new BaseResponse<Item>()
                {
                    Data = Item,
                    Description = "Item successfully found",
                    StatusCode = System.Net.HttpStatusCode.OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Item>()
                {
                    Description = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                };
            }
        }

        public async Task<IBaseResponse<List<Item>>> GetItems(int Page, int PageSize)
        {
            try
            {
                var Items = await itemRepository.GetAll()
                    .Skip((Page - 1) * PageSize)
                    .Take(PageSize)
                    .ToListAsync();

                if (!Items.Any())
                {
                    return new BaseResponse<List<Item>>()
                    {
                        Description = "Items not found",
                        StatusCode = System.Net.HttpStatusCode.NoContent,
                    };
                }

                return new BaseResponse<List<Item>>()
                {
                    Data = Items,
                    Description = "Items successfully found",
                    StatusCode = System.Net.HttpStatusCode.OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<Item>>()
                {
                    Description = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                };
            }
        }

        public async Task<IBaseResponse<List<Item>>> GetItemsByFilter(int Page, int PageSize, string Name, string Seller, MarketStatus Status)
        {
            try
            {
                var query = itemRepository.GetAll();
                if (Name != null)
                {
                    query.Where(item => item.Name == Name);
                }
                if (Seller != null)
                {
                    query.Where(item => item.Sale.Seller == Seller);
                }
                if (Status != MarketStatus.None)
                {
                    query.Where(item => item.Sale.Status == Status);
                }

                var Items = await query.Skip((Page - 1) * PageSize)
                    .Take(PageSize)
                    .ToListAsync();

                if (!Items.Any())
                {
                    return new BaseResponse<List<Item>>()
                    {
                        Description = "Items not found",
                        StatusCode = System.Net.HttpStatusCode.NoContent,
                    };
                }

                return new BaseResponse<List<Item>>()
                {
                    Data = Items,
                    Description = "Items successfully found",
                    StatusCode = System.Net.HttpStatusCode.OK,
                };

            }
            catch (Exception ex)
            {
                return new BaseResponse<List<Item>>()
                {
                    Description = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                };
            }
        }

        public async Task<IBaseResponse<List<Item>>> GetItemsBySorting(int Page, int PageSize, string SortBy, bool IsAsc)
        {
            try
            {
                List<Item> SortedItems;

                switch (SortBy)
                {
                    case "CreatedDt":
                        SortedItems = IsAsc ? 
                            await itemRepository.GetAll()
                            .OrderBy(item => item.Sale.CreateDt).ToListAsync() :
                            await itemRepository.GetAll()
                            .OrderByDescending(item => item.Sale.CreateDt).ToListAsync();
                        break;
                    case "Price":
                        SortedItems = IsAsc ?
                            await itemRepository.GetAll()
                            .OrderBy(item => item.Sale.Price).ToListAsync() :
                            await itemRepository.GetAll()
                            .OrderByDescending(item => item.Sale.Price).ToListAsync();
                        break;
                    default:
                        return new BaseResponse<List<Item>>()
                        {
                            Description = "Bad request",
                            StatusCode = System.Net.HttpStatusCode.BadRequest,
                        };
                }

                if (!SortedItems.Any())
                {
                    return new BaseResponse<List<Item>>()
                    {
                        Description = "Items not found",
                        StatusCode = System.Net.HttpStatusCode.NoContent,
                    };
                }

                SortedItems.Skip((Page - 1) * PageSize).Take(PageSize);
                return new BaseResponse<List<Item>>()
                {
                    Data = SortedItems,
                    Description = "Items successfully sorted",
                    StatusCode = System.Net.HttpStatusCode.OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<Item>>()
                {
                    Description = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                };
            }
        }
    }
}
