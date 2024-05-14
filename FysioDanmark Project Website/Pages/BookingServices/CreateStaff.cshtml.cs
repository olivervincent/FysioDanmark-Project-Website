using FysioDanmark_Project_Website.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FysioDanmark_Project_Website;

public class CreateStaff : PageModel
{
    private IBookingRepository repository;
    [BindProperty]
    public Models.Staff Staff { get; set; }
    public List<Models.Staff> AllStaff { get; set; }
    public CreateStaff(IBookingRepository repo)
    {
        repository = repo;
    }
    public void OnGet()
    {
        AllStaff = repository.GetAllStaff();
    }

    public IActionResult OnPost()
    {
        Staff.Id = 0;
        if (!ModelState.IsValid)
        {
            return Page();
        }
        repository.CreateStaff(Staff);
        AllStaff = repository.GetAllStaff();
        return RedirectToPage("AllStaff");           
    }
}