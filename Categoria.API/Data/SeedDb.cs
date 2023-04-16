using Categoria.API.Data;
using Categoria.Shared.Entities;



namespace Categoria.API.Data

{

    public class SeedDb

    {

        private readonly DataContext _context;



        public SeedDb(DataContext context)

        {

            _context = context;

        }



        public async Task SeedAsync()

        {

            await _context.Database.EnsureCreatedAsync();

            await CheckCountriesAsync();

        }



        private async Task CheckCountriesAsync()

        {

            if (!_context.Products.Any())
            {

                _context.Products.Add(new Product { Name = "Colombia" });

                _context.Products.Add(new Product { Name = "USA" });

                



            }



            await _context.SaveChangesAsync();

        }

    }

}