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
        
        private IBookingRepository bookingRepo;
        private IStaffRepository staffRepo;
        public AllBookingsModel(IBookingRepository bookingrepository, IStaffRepository? staffRepository)
        {
            bookingRepo = bookingrepository;
            staffRepo = staffRepository;
        }
        public List<Models.Bookings> AllBookings { get; private set; } 
        public List<Models.Staff> AllStaff { get; private set; } 
       
        [BindProperty]
        public Models.Bookings Bookings { get; set; }
        public IActionResult OnGet()
        {
            AllBookings = bookingRepo.GetAllBookings();
            AllStaff = staffRepo.GetAllStaff();
            return Page();
        }
        public IActionResult OnPost(int id)
        {
            bookingRepo.DeleteBooking(id);
            AllBookings = bookingRepo.GetAllBookings();
            return RedirectToPage("AllBookings");
        }
    }
}