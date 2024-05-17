using FysioDanmark_Project_Website.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FysioDanmark_Project_Website;

public class AllStaffModel : PageModel
{
    private IStaffRepository repo;
    public AllStaffModel(IStaffRepository repository)
    {
        repo = repository;
    }
    public List<Models.Staff> AllStaff { get; private set; } 
    public IActionResult OnGet()
    {
        AllStaff = repo.GetAllStaff();
        return Page();
    }

    public IActionResult OnPost(int Id)
    {
        repo.DeleteStaff(Id);
        AllStaff = repo.GetAllStaff();
        return RedirectToPage("AllStaff");

    }

}