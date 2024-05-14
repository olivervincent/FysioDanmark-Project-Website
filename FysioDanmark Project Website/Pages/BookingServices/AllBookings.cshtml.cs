using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FysioDanmark_Project_Website.Interfaces;
using FysioDanmark_Project_Website.Models;
using FysioDanmark_Project_Website.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FysioDanmark_Project_Website
{
    public class AllBookingsModel : PageModel
    {
        
        private IBookingRepository catalog;
        public AllBookingsModel(IBookingRepository repository)
        {
            catalog = repository;
        }
        public List<Models.Bookings> AllBookings { get; private set; } 
        public List<Models.Staff> AllStaff { get; private set; } 
       
        [BindProperty]
        public Models.Bookings Bookings { get; set; }
        public IActionResult OnGet()
        {
            AllBookings = catalog.GetAllBookings();
            AllStaff = catalog.GetAllStaff();
            return Page();
        }
        public IActionResult OnPost(int id)
        {
            catalog.DeleteBooking(id);
            AllBookings = catalog.GetAllBookings();
            return RedirectToPage("AllBookings");
        }
    }
}