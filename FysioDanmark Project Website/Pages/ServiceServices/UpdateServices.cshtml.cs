using FysioDanmark_Project_Website.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FysioDanmark_Project_Website.Pages.ServiceServices;

public class UpdateServices : PageModel
{
    private IServicesRepository repo;
    [BindProperty]
    public Models.Services Services { get; set; }
    public UpdateServices(IServicesRepository repository)
    {
        repo = repository;
    }
    public IActionResult OnGet(int id)
    {
        Services = repo.GetService(id);
        return Page();
    }

    public IActionResult OnPost()
    {
            
        repo.UpdateService(Services);
        return RedirectToPage("ManageServices");
    }
}