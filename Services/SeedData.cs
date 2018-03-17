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

            #region ProductCategoriesRegion           
            if (!context.ProductCategories.Any())
            {
                context.ProductCategories.AddRange(new ProductCategory()
                {
                    CategoryName = "Beauty",
                    CategoryId = Guid.Parse("baa8a556-8f0d-4a9e-8661-f459af643a8c")
                },
                new ProductCategory()
                {
                    CategoryName = "Clothing",
                    CategoryId = Guid.Parse("50a8e2ae-4e8c-4d30-be4e-f3e478a4177a")
                },

                new ProductCategory()
                {
                    CategoryName = "Office Furniture",
                    CategoryId = Guid.Parse("d1bbd1d3-c950-4dfa-ac72-8f49adbd5fc0")
                },

                new ProductCategory()
                {
                    CategoryName = "Electronics",
                    CategoryId = Guid.Parse("816f2387-147e-4bc5-812e-b45add862208")
                });
            }

            #endregion ProductCategoriesRegion

            #region PaymentOption
            if (!context.PaymentMethods.Any()){
                context.PaymentMethods.AddRange(
                    new PaymentMethod() {
                    Name="Mpesa",
                    PaymentMethodId= Guid.Parse("816f2387-147e-4bc5-812e-b45cdd862238")
                    },

                     new PaymentMethod()
                     {
                         Name = "Cash on delivery",
                         PaymentMethodId = Guid.Parse("866f8387-147e-4bc5-812e-b45cdd862238")
                     }
                    );
            }

            #endregion PaymentOption
            #region ShipmentMethod
            if (!context.ShipmentMethods.Any()) {
                context.ShipmentMethods.AddRange(
                    new ShipmentMethod() {
                    Name="Self pick up",
                    ShipmentMethodId = Guid.Parse("866f8387-147e-4bc5-812e-b45cdd862238")
                    },
                     new ShipmentMethod()
                     {
                         Name = "Default shipment method",
                         ShipmentMethodId = Guid.Parse("866f3387-147e-4bc5-812e-b45c8d862238")
                     }
                    );
            }
            #endregion ShipmentMethod

            #region Products
            if (!context.Products.Any()) { 
                context.Products.AddRange(
                     new Product
                     {
                         ProductName = "Window Air 2",
                         ProductId = Guid.NewGuid(),
                         ProductMediaFile = "https://ionicframework.com/dist/preview-app/www/assets/img/nin-live.png",
                         ProductManufacturer = "LG",
                         ShopperReview = new Random().Next(1, 5),
                         Price = (decimal)(new Random().NextDouble()) * 100000m,
                         ProductCategory = Guid.Parse("816f2387-147e-4bc5-812e-b45add862208")
                     },
                      new Product
                      {
                          ProductName = "Samsung Galaxy s9",
                          ProductId = Guid.NewGuid(),
                          ProductMediaFile = "https://ionicframework.com/dist/preview-app/www/assets/img/nin-live.png",
                          ProductManufacturer = "Samsung",
                          ShopperReview = new Random().Next(1, 5),
                          Price = (decimal)(new Random().NextDouble()) * 100000m,
                          ProductCategory = Guid.Parse("816f2387-147e-4bc5-812e-b45add862208")
                      },

                     new Product
                     {
                         ProductName = "Dvd Home Theater System",
                         ProductId = Guid.NewGuid(),
                         ProductMediaFile = "https://ionicframework.com/dist/preview-app/www/assets/img/nin-live.png",
                         ProductManufacturer = "Samsung",
                         ShopperReview = new Random().Next(1, 5),
                         Price = (decimal)(new Random().NextDouble()) * 100000m,
                         ProductCategory = Guid.Parse("816f2387-147e-4bc5-812e-b45add862208")
                     },

                    new Product
                    {
                        ProductName = "Dell Insprion 12645",
                        ProductId = Guid.NewGuid(),
                        ProductMediaFile = "https://ionicframework.com/dist/preview-app/www/assets/img/nin-live.png",
                        ProductManufacturer = "Dell",
                        ShopperReview = new Random().Next(1, 5),
                        Price = (decimal)(new Random().NextDouble()) * 100000m,
                        ProductCategory = Guid.Parse("816f2387-147e-4bc5-812e-b45add862208")
                    }
                );
                #endregion Products
            }
            context.SaveChanges();
        }
    }
}
