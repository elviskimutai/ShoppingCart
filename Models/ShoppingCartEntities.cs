using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApi.Models
{
    /// <summary>
    /// Contains models mapped to the db
    /// </summary>
    public class Product {
        [Required]
        public string ProductName { get; set; }
        public string ProductMediaFile { get; set; }
        public string ProductSku { get; set; }
        public Guid ProductCategory { get; set; }
        public string ProductManufacturer { get; set; }
        public decimal Price { get; set; }
        public int ShopperReview { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProductId { get; set; }
    }

    public class ProductCategory {
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public string Description { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CategoryId { get; set; }
    }
    public class Shopper {
        [Required]
        public string UserName { get; set; }
        public string DispalyedName { get; set; }
        [Required]
        public String Email { get; set; }
        public string ShopperGroup { get; set; }
        public bool IsVendor { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid ShopperId{ get; set; }
    }

    public class Order {
        public string OrderNo { get; set; }
        public string Email { get; set; }
        public string PaymentMethod { get; set; }
        public string Shipment { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public bool NotifyShopper { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid OrderId { get; set; }
    }
    public class Manufacturer {
        [Required]
        public string ManufacturerName { get; set; }
        public string ManufacturerEmail { get; set; }
        public string ManufacturerCategory { get; set; }
        public string ManufacturerUrl { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ManufacturerId { get; set; }
    }
    public class ManufacturerCategory {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CategoryId { get; set; }
    }

    public class ShipmentMethod {
        [Required]
        public string Name { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ShipmentMethodId { get; set; }
        public string Description { get; set; }
    }

    public class PaymentMethod {
        [Required]
        public string Name { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PaymentMethodId { get; set; }
        public string Description { get; set; }
    }
}
