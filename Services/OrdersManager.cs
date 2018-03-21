using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ShoppingCartApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;

namespace ShoppingCartApi.Services
{
    public class OrdersManager : IRepository<Order>
    {
        private readonly ShoppingCartDbContext _dbContext;
        private readonly IOptions<StkSetting> _stkSettings;
        private readonly IOptions<ShoppingCartStkPushKey> _shoppingCartStkPushKey;
        private readonly IOptions<ShoppingCartStkPushKey> shoppingCartStkPushKey;
        public OrdersManager(ShoppingCartDbContext dbContext, IOptions<StkSetting> stkSettings, IOptions<ShoppingCartStkPushKey> shoppingCartStkPushKey)
        {
            _dbContext = dbContext;
            _stkSettings = stkSettings;
            _shoppingCartStkPushKey = shoppingCartStkPushKey;
          



        }



        public bool Add(Order order)
        {
            try
            {
                this._dbContext.Orders.Add(order);
              
                this._dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public IEnumerable<Order> GetAll()
        {
            var orders = this._dbContext.Orders.ToList();
            return orders;
        }

        public Order GetById(Guid id)
        {
            var order = this._dbContext.Orders.Find(id);
            return order;
        }

        public bool Remove(Guid id)
        {
            try
            {
                var order = this._dbContext.Orders.Find(id);
                this._dbContext.Remove(order);
                this._dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
           

        }

        public bool CreateNewOrder(CustomerOrder customerOrder) {
            try
            {
                var order = new Order() {
                    CustomerId = customerOrder.CustomerId,
                    Email = customerOrder.Email,
                    NotifyShopper = customerOrder.NotifyShopper,
                    OrderDate = DateTime.Now,
                    OrderId = Guid.NewGuid(),
                    PaymentMethodId=customerOrder.PaymentMethodId,
                    ShipmentMethodId=customerOrder.ShipmentMethodId,
                    Status="New Order" 
                };

                var billingInfo = new BillingInfo() {
                   City= customerOrder.BillingInfo?.City,
                   CompanyName=customerOrder.BillingInfo?.CompanyName,
                   FirstName= customerOrder.BillingInfo?.FirstName,
                   LastName =customerOrder.BillingInfo?.LastName,
                   OrderId = order.OrderId,
                   PostalCode= customerOrder.BillingInfo?.PostalCode,
                   Address= customerOrder.BillingInfo?.Address,
                   PhoneNumber =customerOrder.BillingInfo?.PhoneNumber
                };
                var orderItems = new List<OrderItem>();
                foreach (var orderitem in customerOrder.OrderItems)
                {
                    orderItems.Add(new OrderItem() {
                        OrderId=  order.OrderId,
                        Price= orderitem.Price,
                        ProductId=orderitem.ProductId,
                        Qty= orderitem.Qty,
                        Total= orderitem.Total,
                    });

                }
                this._dbContext.Orders.Add(order);
                this._dbContext.BillingInfos.Add(billingInfo);
                this._dbContext.OrderItems.AddRange(orderItems);
                this._dbContext.SaveChanges();
                SendStkPushNotifaction();
                return true;
            }
            catch (Exception)
            {

                throw;
            }

           
        }
        private void SendStkPushNotifaction() {
            
          
            ShoppingCartApiAccessToken shoppingCartApiAccessToken = GetAuthToken();
            var result =  "https://sandbox.safaricom.co.ke/mpesa/stkpush/v1/processrequest"                
                .WithOAuthBearerToken(shoppingCartApiAccessToken.AccessToken)
                .PostJsonAsync(this._stkSettings.Value)
                .ReceiveString().Result;
        }


        private ShoppingCartApiAccessToken GetAuthToken() {

            var result = _shoppingCartStkPushKey.Value.Url
                .WithBasicAuth(_shoppingCartStkPushKey.Value.ConsumerKey, _shoppingCartStkPushKey.Value.ConsumerSecret)
                .GetStringAsync().Result;
           ShoppingCartApiAccessToken shoppingCartApiAccessToken = JsonConvert.DeserializeObject<ShoppingCartApiAccessToken>(result);
           Debug.Write(JsonConvert.SerializeObject(this._stkSettings.Value));
           return shoppingCartApiAccessToken;
        }
    }
}
