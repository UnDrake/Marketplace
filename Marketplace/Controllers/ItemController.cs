using FitnessArchitecture.Domain.Enum;
using Marketplace.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Marketplace.Controllers
{
    [ApiController]
    [Route("api/v0.1/auctions")]
    public class ItemController : Controller
    {
        private readonly IItemService itemService;
        public ItemController(IItemService itemService)
        {
            this.itemService = itemService;
        }

        [HttpPost]
        public async Task<IActionResult> GetItems(int Page, int PageSize)
        {
            var items = await itemService.GetItems(Page, PageSize);
            if (items.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return View(items.Data);
            }
            ViewBag.Description = items.Description;
            ViewBag.StatusCode = ((int)items.StatusCode);
            return View("Error");
        }

        [HttpPost]
        public async Task<IActionResult> GetItemsByFilter(int Page, int PageSize, string Name, string Seller, MarketStatus Status)
        {
            var items = await itemService.GetItemsByFilter(Page, PageSize, Name, Seller, Status);
            if (items.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return View(items.Data);
            }
            ViewBag.Description = items.Description;
            ViewBag.StatusCode = ((int)items.StatusCode);
            return View("Error");
        }

        [HttpPost]
        public async Task<IActionResult> GetItemsBySort(int Page, int PageSize, string SortBy, bool IsAsc)
        {
            var items = await itemService.GetItemsBySorting(Page, PageSize, SortBy, IsAsc);
            if (items.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return View(items.Data);
            }
            ViewBag.Description = items.Description;
            ViewBag.StatusCode = ((int)items.StatusCode);
            return View("Error");
        }

        [HttpPost]
        public async Task<IActionResult> GetItemById(int Id)
        {
            var item = await itemService.GetItemById(Id);
            if (item.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return View(item.Data);
            }
            ViewBag.Description = item.Description;
            ViewBag.StatusCode = ((int)item.StatusCode);
            return View("Error");
        }

        [HttpPost]
        public async Task<IActionResult> GetItemByName(string Name)
        {
            var item = await itemService.GetItemByName(Name);
            if (item.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return View(item.Data);
            }
            ViewBag.Description = item.Description;
            ViewBag.StatusCode = ((int)item.StatusCode);
            return View("Error");
        }
    }
}
