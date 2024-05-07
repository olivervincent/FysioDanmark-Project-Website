using FysioDanmark_Project_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Threading.Tasks;
using FysioDanmark_Project_Website.Models;

namespace FysioDanmark_Project_Website.Interfaces
{
    public interface IBookingRepository
    {
         void AddBooking(Clients clients, string staff, DateTime dateTime);
         List<Models.Bookings> GetAllBookings();
    }
}
