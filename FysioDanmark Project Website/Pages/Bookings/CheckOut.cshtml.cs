using System;
using System.Threading.Tasks.Dataflow;
using FysioDanmark_Project_Website.Models;
using FysioDanmark_Project_Website.Repositories;
using FysioDanmark_Project_Website.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FysioDanmark_Project_Website.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FysioDanmark_Project_Website;

public class CheckOut : PageModel
{
    public JsonBookingRepository JsonBookingRepository { get; set; }
    
    [BindProperty]
    public Clients Clients { get; set; }
    [BindProperty]
    public string StaffName { get; set; }
    [BindProperty]
    public DateTime DateTime { get; set; }

    public CheckOut(JsonBookingRepository repository)
    {
        JsonBookingRepository = repository;
    }
    
    public IActionResult OnGet()
    {
        return Page();
    }

    public IActionResult OnPost()
    {
       if (DateTime < DateTime.Now)
        {
            ModelState.AddModelError("", "Invalid date and time");
            return Page();
        }
        if (!ModelState.IsValid)
        {
            return Page();
        }
        JsonBookingRepository.AddBooking(Clients, StaffName, DateTime);
        return RedirectToPage("BookingPage", new { Name = Clients.Name});
    }
}