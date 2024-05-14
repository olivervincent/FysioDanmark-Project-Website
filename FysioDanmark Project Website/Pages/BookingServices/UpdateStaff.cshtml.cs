using FysioDanmark_Project_Website.Interfaces;
using FysioDanmark_Project_Website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FysioDanmark_Project_Website.Pages.BookingServices
{
    public class UpdateStaffModel : PageModel
    {
        private IBookingRepository repo;
        [BindProperty]
        public Models.Staff Staff { get; set; }
        public UpdateStaffModel(IBookingRepository repository)
        {
            repo = repository;
        }
        public IActionResult OnGet(string name)
        {
            Staff = repo.GetStaff(name);
            return Page();

        }

        public IActionResult OnPost()
        {
            
            repo.UpdateStaff(Staff);
            return RedirectToPage("AllStaff");
        }


       
    }
}
