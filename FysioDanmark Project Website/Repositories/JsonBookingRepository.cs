using FysioDanmark_Project_Website.Interfaces;
using FysioDanmark_Project_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Threading.Tasks;
using FysioDanmark_Project_Website.Services;

namespace FysioDanmark_Project_Website.Repositories
{
    public class JsonBookingRepository :IBookingRepository
    {
        const string JsonFilePath = "/Users/olivervincent/Desktop/Zealand/FysioDanmark Project Website/FysioDanmark Project Website/Data/JsonBookings.json";
        private const string JsonStaffPath = "/Users/olivervincent/Desktop/Zealand/FysioDanmark Project Website/FysioDanmark Project Website/Data/JsonStaffs.json";
        private List<Bookings> JsonBookings { get; set; }
        private Bookings Bookings { get; set; }
        
        public List<Models.Bookings> GetAllBookings()
        {
            return JsonFileReader.ReadJsonBooking(JsonFilePath);
        }

        public Staff GetStaff(string name)
        {
            foreach (var item in GetAllStaffs())
            {
                if (item.Name == name)
                    return item;
            }

            return new Models.Staff();
        }
        
        public List<Models.Staff> GetAllStaffs()
        {
            return JsonFileReader.ReadJsonStaff(JsonStaffPath);
        }
        
        public void AddBooking(Clients clients, string staff, DateTime dateTime)
        { 
            Bookings = new Bookings();
            Bookings.Clients = clients;
            Bookings.Staff = GetStaff(staff);
            Bookings.DateTime = dateTime;
            Bookings.Services = ShoppingCartService.GetBookingItems();
            Bookings.BookingId = JsonFileReader.ReadJsonBooking(JsonFilePath).Count + 1;
            
            JsonBookings = JsonFileReader.ReadJsonBooking(JsonFilePath);
            JsonBookings.Add(Bookings);
            JsonFileWritter.WriteToJsonBooking(JsonBookings, JsonFilePath);
        }

    }
}
