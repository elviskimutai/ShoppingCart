using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCartApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ShoppingCartDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<ShoppingCartDbContext>>()))
        {
            // Look for any movies.
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            context.Products.AddRange(
                 new Product
                 {
                     ProductName = "Ghostbusters 2",
                     ProductId = Guid.NewGuid(),
                     ProductMediaFile = "https://ionicframework.com/dist/preview-app/www/assets/img/nin-live.png",
                     ProductManufacturer = "Samsung",
                     ShopperReview = new Random().Next(1, 5)
                 },
                  new Product
                  {
                      ProductName = "Ghostbusters 2",
                      ProductId = Guid.NewGuid(),
                      ProductMediaFile = "https://ionicframework.com/dist/preview-app/www/assets/img/nin-live.png",
                      ProductManufacturer = "Samsung",
                      ShopperReview = new Random().Next(1, 5)
                  },

                 new Product
                 {
                     ProductName = "Ghostbusters 2",
                     ProductId = Guid.NewGuid(),
                     ProductMediaFile = "https://ionicframework.com/dist/preview-app/www/assets/img/nin-live.png",
                     ProductManufacturer = "Samsung",
                     ShopperReview = new Random().Next(1, 5)
                 },

                new Product
                {
                    ProductName = "Ghostbusters 2",
                    ProductId = Guid.NewGuid(),
                    ProductMediaFile = "https://ionicframework.com/dist/preview-app/www/assets/img/nin-live.png",
                    ProductManufacturer = "Sony",
                    ShopperReview = new Random().Next(1,5)
                }
            );
            context.SaveChanges();
        }
    }
}
