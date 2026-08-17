using LiveShoppingList.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LiveShoppingList.Models;
using LiveShoppingList.DTOs;

namespace LiveShoppingList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingItemsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ShoppingItemsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _context.ShoppingItems.ToListAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddTask(ShoppingItemsDto shopITEM)
        {
            var newList = new ShoppingItem
            {
                Name = shopITEM.Name,
                Quantity = shopITEM.Quantity,
            };
            var itemtoAdd =_context.ShoppingItems.Add(newList);
            await _context.SaveChangesAsync();
            return Ok(newList);

        }

        //[HttpPut]

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetListByID()
        //{

        //}

        //[HttpDelete]
    }
}
