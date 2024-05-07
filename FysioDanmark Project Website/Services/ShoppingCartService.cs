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
        //public Repositories.JsonBookRepository repo;
        
        public ShoppingCartService()
        {
            ShoppingCart = new List<Models.Services>();
            //repo = repository;
        }
        
        public void AddToCart(Models.Services services)
        {
            //Book bookToAdd = repo.GetBook(ISBN);
            ShoppingCart.Add(services);
        }

        public void RemoveBookFromCart(Models.Services services)
        {
            //Book bookToRemove = repo.GetBook(book.ISBN);
            foreach (var booklist in ShoppingCart)
            {
                if (booklist.ISBN == services.ISBN)
                {
                    ShoppingCart.Remove(booklist);
                    break;
                }
            }
        }

        public double CalcTotalPrice()
        {
            double totalPrice = 0;
            foreach (Models.Services book in ShoppingCart)
            {
                totalPrice += book.Price;
            }

            return totalPrice;
        }
        
        public static List<Models.Services> GetOrderedItems()
        {
            List<Models.Services> shoppingCart = ShoppingCart;
            return shoppingCart;
        }
    }
}
