using FysioDanmark_Project_Website.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FysioDanmark_Project_Website;

public class ManageServices : PageModel
{
    private IServicesRepository repository;
    [BindProperty]
    public Models.Services Services { get; set; }
    public List<Models.Services> AllServices { get; set; }
    public ManageServices(IServicesRepository repo)
    {
        repository = repo;
    }
    public void OnGet()
    {
        AllServices = repository.GetAllServices();
    }

    public IActionResult OnPost(int Id)
    {
        repository.DeleteService(Id);
        AllServices = repository.GetAllServices();
        return RedirectToPage("ManageServices");           
    }
}