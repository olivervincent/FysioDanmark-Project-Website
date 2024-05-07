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
    public class AllServicesModel : PageModel
    {
        
        private IServicesRepository catalog;
        public AllServicesModel(IServicesRepository repository)
        {
            catalog = repository;
        }
        public List<Models.Services> AllServices { get; private set; } 
       
        [BindProperty]
        public Models.Services Services { get; set; }
        public IActionResult OnGet()
        {
            AllServices = catalog.GetAllServices();
            return Page();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                catalog.AddService(Services);
                AllServices = catalog.GetAllServices();
            }
            return Page();
        }
    }
}