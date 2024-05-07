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
        public static List<Book> ShoppingCart { get; set; } = new List<Book>();
        //public Repositories.JsonBookRepository repo;
        
        public ShoppingCartService()
        {
            ShoppingCart = new List<Book>();
            //repo = repository;
        }
        
        public void AddToCart(Book book)
        {
            //Book bookToAdd = repo.GetBook(ISBN);
            ShoppingCart.Add(book);
        }

        public void RemoveBookFromCart(Book book)
        {
            //Book bookToRemove = repo.GetBook(book.ISBN);
            foreach (var booklist in ShoppingCart)
            {
                if (booklist.ISBN == book.ISBN)
                {
                    ShoppingCart.Remove(booklist);
                    break;
                }
            }
        }

        public double CalcTotalPrice()
        {
            double totalPrice = 0;
            foreach (Book book in ShoppingCart)
            {
                totalPrice += book.Price;
            }

            return totalPrice;
        }
        
        public static List<Book> GetOrderedItems()
        {
            List<Book> shoppingCart = ShoppingCart;
            return shoppingCart;
        }
    }
}
