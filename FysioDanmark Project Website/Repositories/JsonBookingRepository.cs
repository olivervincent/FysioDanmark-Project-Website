using FysioDanmark_Project_Website.Interfaces;
using FysioDanmark_Project_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Threading.Tasks;
using System.Xml.XPath;
using FysioDanmark_Project_Website.Data;
using FysioDanmark_Project_Website.Services;
using Newtonsoft.Json;

namespace FysioDanmark_Project_Website.Repositories
{
    public class JsonBookingRepository:IBookingRepository
    {
        private string JsonBookingsPath = new Paths().JsonBookingsPath;
        private List<Bookings> JsonBookings { get; set; }
        private Bookings Bookings { get; set; }
        
        public List<Models.Bookings> GetAllBookings()
        {
            return JsonFileReader.ReadJsonBooking(JsonBookingsPath);
        }

        
        public Bookings GetBooking(int id)
        {
            foreach (var item in GetAllBookings())
            {
                if (item.BookingId == id)
                    return item;
            }

            return new Models.Bookings();
        }

        public void DeleteBooking(int id)
        {
            JsonBookings = GetAllBookings();
            JsonBookings.RemoveAll(s => s.BookingId == id);
            JsonFileWritter.WriteToJsonBooking(JsonBookings, JsonBookingsPath);
        }
        
        public void UpdateBooking(Bookings booking)
        {
            if (booking != null)
            {
                JsonBookings = JsonFileReader.ReadJsonBooking(JsonBookingsPath);
                JsonBookings.RemoveAll(s => s.BookingId == booking.BookingId);
                JsonBookings.Add(booking);
                JsonFileWritter.WriteToJsonBooking(JsonBookings, JsonBookingsPath);
            }
        }
        public void AddBooking(Clients clients, string staff, DateTime dateTime)
        { 
            Bookings = new Bookings();
            Bookings.Clients = clients;
            Bookings.Clients.Id = GetAllBookings().Count + 1;
            Bookings.Staff = new JsonStaffRepository().GetStaff(staff);
            Bookings.DateTime = dateTime;
            Bookings.Services = ShoppingCartService.GetBookingItems();
            double totalPrice = 0;
            foreach (Models.Services service  in ShoppingCartService.GetBookingItems())
            {
                totalPrice = totalPrice + service.Price;
            }

            Bookings.TotalPrice = totalPrice;
            Bookings.BookingId = JsonFileReader.ReadJsonBooking(JsonBookingsPath).Count + 1;
            
            JsonBookings = JsonFileReader.ReadJsonBooking(JsonBookingsPath);
            JsonBookings.Add(Bookings);
            JsonFileWritter.WriteToJsonBooking(JsonBookings, JsonBookingsPath);
        }

    }
}
