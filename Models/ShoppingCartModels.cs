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
        public Order Order { get; set; }
        public BillingInfo BillingInfo { get; set; }
        public List<OrderItem> OrderItemList { get; set; }

    }
}
