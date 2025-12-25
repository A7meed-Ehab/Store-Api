using Microsoft.EntityFrameworkCore;
using Store.Domain.Contracts;
using Store.Domain.Entities.Products;
using Store.Persistance.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Persistance
{
    public class DbInitializer(StoreDbContext _context) : IDbInititializer
    {
        //private readonly StoreDbContext _context;

        //public DbInitializer(StoreDbContext context)
        //{
        //    _context = context;
        //}

        public async Task InitializeAsync()
        {
            // Check and apply pending migrations
            var pendingMigrations = await _context.Database.GetPendingMigrationsAsync();
            if (pendingMigrations.Any())
            {
                await _context.Database.MigrateAsync();
            }


            // Seed Brands
            if (!_context.ProductBrands.Any())
            {
                var brandsData = await File.ReadAllTextAsync(@"..\Infrastructure\Store.Persistance\Data\DataSeed\brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                if (brands is not null && brands.Count > 0)
                {
                    await _context.ProductBrands.AddRangeAsync(brands);
                    await _context.SaveChangesAsync();
                }
            }

            // Seed Types
            if (!_context.ProductTypes.Any())
            {
                var typesData = await File.ReadAllTextAsync(@"..\Infrastructure\Store.Persistance\Data\DataSeed\types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData); // ✅ Correct type
                if (types is not null && types.Count > 0)
                {
                    await _context.ProductTypes.AddRangeAsync(types); // ✅ Correct DbSet
                    await _context.SaveChangesAsync();
                }
            }

            // Seed Products
            if (!_context.Products.Any())
            {
                var productsData = await File.ReadAllTextAsync(@"..\Infrastructure\Store.Persistance\Data\DataSeed\products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData); // ✅ Correct type
                if (products is not null && products.Count > 0)
                {
                    await _context.Products.AddRangeAsync(products); // ✅ Correct DbSet
                    await _context.SaveChangesAsync();
                }
            }
        }

        private async Task<string> ReadSeedFileAsync(string fileName)
        {
            // Look for files in the project directory
            var seedPath = Path.Combine(AppContext.BaseDirectory, "DataSeed", fileName);

            // If file doesn't exist in bin directory, try relative to project
            if (!File.Exists(seedPath))
            {
                seedPath = Path.Combine(Directory.GetCurrentDirectory(), "DataSeed", fileName);
            }

            if (!File.Exists(seedPath))
            {
                throw new FileNotFoundException($"Seed file not found: {seedPath}");
            }

            return await File.ReadAllTextAsync(seedPath);
        }
    }
}