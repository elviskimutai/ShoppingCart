using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApi.Models
{
    /// <summary>
    /// contains models not mapped to the db
    /// </summary>
    public class ShoppingCartModels
    {
    }

    public class CustomerOrder {                     
            public string Email { get; set; }            
            public Guid PaymentMethodId { get; set; }          
            public Guid ShipmentMethodId { get; set; }           
            public DateTime OrderDate { get; set; }
            public string Status { get; set; }
            public bool NotifyShopper { get; set; }
           
            public Guid OrderId { get; set; }
            public string CustomerId { get; set; }           
            public  BillingInfo BillingInfo { get; set; }
            //public List<OrderItem> OrderItems { get; set; }


        

    }
}
