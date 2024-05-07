using FysioDanmark_Project_Website.Interfaces;
using FysioDanmark_Project_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FysioDanmark_Project_Website.Services;

namespace FysioDanmark_Project_Website.Repositories
{
    public class JsonOrderRepository :IOrderRepository
    {
        const string JsonFilePath = "/Users/olivervincent/Desktop/Zealand/Software Construction/RP_UnSolved-master/RazorPages_Exercises/Book_StoreV10/Book_StoreV10/Data/JsonBookOrders.json";
        private List<Order> JsonOrders { get; set; }
        private Order Order { get; set; }
        
        public void AddOrder(Student student)
        { 
            Order = new Order();
            Order.Student = student;
            Order.DateTime = DateTime.Now;
            Order.Books = ShoppingCartService.GetOrderedItems();
            Order.OrderId = JsonFileReader.ReadJsonOrder(JsonFilePath).Count + 1;
            
            JsonOrders = JsonFileReader.ReadJsonOrder(JsonFilePath);
            JsonOrders.Add(Order);
            JsonFileWritter.WriteToJsonOrder(JsonOrders, JsonFilePath);
        }

    }
}
