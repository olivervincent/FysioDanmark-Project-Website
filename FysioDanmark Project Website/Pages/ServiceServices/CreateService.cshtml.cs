using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FysioDanmark_Project_Website.Interfaces;
using FysioDanmark_Project_Website.Models;
using FysioDanmark_Project_Website.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FysioDanmark_Project_Website;

public class CreateServiceModel : PageModel
{
    private IServicesRepository repository;
    [BindProperty]
    public Models.Services Services { get; set; }
    public List<Models.Services> AllServices { get; set; }
    public CreateServiceModel(IServicesRepository repo)
    {
        repository = repo;
    }
    public void OnGet()
    {
        AllServices = repository.GetAllServices();
    }

    public IActionResult OnPost()
    {
        Services.Id = 1;
        if (!ModelState.IsValid)
        {
            AllServices = repository.GetAllServices();
            return Page();
        }
        repository.AddService(Services);
        AllServices = repository.GetAllServices();
        return RedirectToPage("ManageServices");           
    }
}