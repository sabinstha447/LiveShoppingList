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

        [HttpPut("{id}")]
        public async Task<IActionResult> EditShoppingList(int id, [FromBody] ShoppingItemsDto dto)
        {
            var findItems = await _context.ShoppingItems.FindAsync(id);
            if (findItems == null)
            {
                return NotFound();
            }

            findItems.Name = dto.Name;
            findItems.Quantity = dto.Quantity;
            await _context.SaveChangesAsync();
            return NoContent();
          
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetListByID( int id)
        {
            var findItems = await _context.ShoppingItems.FindAsync(id);
            if(findItems == null)
            {
                return NotFound();
            }
            return Ok(findItems);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DelShopItem( int id)
        {
            var delItem = await _context.ShoppingItems.FindAsync(id);
            if(delItem == null)
            {
                return NotFound();
            }
             _context.ShoppingItems.Remove(delItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
