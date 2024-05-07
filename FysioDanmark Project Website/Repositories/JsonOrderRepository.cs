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
        private List<Bookings> JsonOrders { get; set; }
        private Bookings Bookings { get; set; }
        
        public void AddOrder(Clients clients)
        { 
            Bookings = new Bookings();
            Bookings.Clients = clients;
            Bookings.DateTime = DateTime.Now;
            Bookings.Books = ShoppingCartService.GetOrderedItems();
            Bookings.OrderId = JsonFileReader.ReadJsonOrder(JsonFilePath).Count + 1;
            
            JsonOrders = JsonFileReader.ReadJsonOrder(JsonFilePath);
            JsonOrders.Add(Bookings);
            JsonFileWritter.WriteToJsonOrder(JsonOrders, JsonFilePath);
        }

    }
}
