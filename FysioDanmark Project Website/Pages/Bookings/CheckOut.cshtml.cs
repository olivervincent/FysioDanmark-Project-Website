using System;
using System.Threading.Tasks.Dataflow;
using FysioDanmark_Project_Website.Models;
using FysioDanmark_Project_Website.Repositories;
using FysioDanmark_Project_Website.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FysioDanmark_Project_Website.Models;

namespace FysioDanmark_Project_Website;

public class CheckOut : PageModel
{
    public JsonBookingRepository JsonBookingRepository { get; set; }
    
    [BindProperty]
    public Clients Clients { get; set; }
    [BindProperty]
    public Staff Staffs { get; set; }
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
        JsonBookingRepository.AddBooking(Clients, Staffs.Name, DateTime);
        return RedirectToPage("BookingPage", new { Name = Clients.Name});
    }
}