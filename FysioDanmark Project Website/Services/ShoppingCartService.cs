using FysioDanmark_Project_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FysioDanmark_Project_Website.Interfaces;

namespace FysioDanmark_Project_Website.Services
{
    public class ShoppingCartService
    {
        public static List<Models.Services> ShoppingCart { get; set; } = new List<Models.Services>();
        
        public ShoppingCartService()
        {
            ShoppingCart = new List<Models.Services>();
        }
        
        public void AddToCart(Models.Services services)
        {
            ShoppingCart.Add(services);
        }

        public void RemoveServiceFromCart(Models.Services services)
        {
            foreach (var serviceList in ShoppingCart)
            {
                if (serviceList.Id == services.Id)
                {
                    ShoppingCart.Remove(serviceList);
                    break;
                }
            }
        }

        public double CalcTotalPrice()
        {
            double totalPrice = 0;
            foreach (Models.Services service in ShoppingCart)
            {
                totalPrice += service.Price;
            }

            return totalPrice;
        }
        
        public static List<Models.Services> GetBookingItems()
        {
            List<Models.Services> shoppingCart = ShoppingCart;
            return shoppingCart;
        }
    }
}
