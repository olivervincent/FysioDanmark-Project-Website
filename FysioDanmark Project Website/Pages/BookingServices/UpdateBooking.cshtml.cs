using FysioDanmark_Project_Website.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FysioDanmark_Project_Website.Pages.BookingServices;

public class UpdateBooking : PageModel
{
    private IBookingRepository repo;
    [BindProperty]
    public Models.Bookings Booking { get; set; }
    [BindProperty]
    public string serviceNames { get; set; }
    public UpdateBooking(IBookingRepository repository)
    {
        repo = repository;
    }
    public IActionResult OnGet(int id)
    {
        Booking = repo.GetBooking(id);
        foreach (Models.Services service in Booking.Services)
        {
            serviceNames += service.Title + ", ";
        }
        return Page();
    }

    public IActionResult OnPost()
    {
            
        repo.UpdateBooking(Booking);
        return RedirectToPage("AllServices");
    }
}