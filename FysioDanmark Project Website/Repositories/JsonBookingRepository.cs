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
    public class JsonBookingRepository :IBookingRepository
    {
        private string JsonBookingsPath = new Paths().JsonBookingsPath;
        private string JsonStaffPath = new Paths().JsonStaffPath;
        private List<Bookings> JsonBookings { get; set; }
        private List<Staff> JsonStaff { get; set; }
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
        
        public List<Models.Staff> GetAllStaff()
        {
            return JsonFileReader.ReadJsonStaff(JsonStaffPath);
        }

        public void UpdateStaff(Staff staff)
        {
            if (staff != null)
            {
                JsonStaff = JsonFileReader.ReadJsonStaff(JsonStaffPath);
                DeleteStaff(staff.Id);
                JsonStaff.Add(staff);
                JsonFileWritter.WriteToJsonStaff(JsonStaff, JsonStaffPath);
            }
        }

    public void DeleteStaff(int Id)
        {
            JsonStaff = JsonFileReader.ReadJsonStaff(JsonStaffPath);
            JsonStaff.RemoveAll(s => s.Id == Id);
            JsonFileWritter.WriteToJsonStaff(JsonStaff, JsonStaffPath);
        }

        public void CreateStaff(Staff staff)
        {
            JsonStaff = JsonFileReader.ReadJsonStaff(JsonStaffPath);
            int Id = 1;
            if (JsonStaff.Any()) 
            {
                Id = JsonStaff.Max(x => x.Id) + 1;
            }
            staff.Id = Id;

            JsonStaff.Add(staff);
            JsonFileWritter.WriteToJsonStaff(JsonStaff.OrderBy(x => x.Id).ToList(), JsonStaffPath);
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
            Bookings.Clients.Id = GetAllBookings().Count + 1;
            Bookings.Staff = GetStaff(staff);
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
