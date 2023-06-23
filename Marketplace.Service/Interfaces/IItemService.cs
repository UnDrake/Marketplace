using FitnessArchitecture.Domain.Enum;
using FitnessArchitecture.Domain.Response;
using Marketplace.Domain.Models;

namespace Marketplace.Service.Interfaces
{
    public interface IItemService
    {
        Task<IBaseResponse<Item>> GetItemById(int ID);
        Task<IBaseResponse<Item>> GetItemByName(string Name);
        Task<IBaseResponse<List<Item>>> GetItemsByFilter(int Page, int PageSize, string Name, string Seller, MarketStatus Status);
        Task<IBaseResponse<List<Item>>> GetItemsBySorting(int Page, int PageSize, string SortBy, bool IsAsc);
        Task<IBaseResponse<List<Item>>> GetItems(int Page, int PageSize);
    }
}
