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

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id ){

            var product =await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product is null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        //Actualizacion
        [HttpPut]
        public async Task<ActionResult>put(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }


        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)

        {

            var afectedRows = await _context.Products

            .Where(x => x.Id == id)

            .ExecuteDeleteAsync();

            if (afectedRows == 0)

            {

                return NotFound();

            }

            return NoContent();

        }







    }
}
