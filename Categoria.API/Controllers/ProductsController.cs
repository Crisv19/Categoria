using Categoria.API.Data;
using Categoria.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Categoria.API.Controllers
{
    [ApiController]
    [Route("/api/products")]
    public class ProductsController:ControllerBase
    {
        private readonly DataContext _context;

        public ProductsController(DataContext context)

        {

            _context = context;

        }

        [HttpPost]
        public async Task<ActionResult>Post(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return Ok();

        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Products.ToListAsync());
        }






    }
}
