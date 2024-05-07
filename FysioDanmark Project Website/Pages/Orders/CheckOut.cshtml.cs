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
    public JsonOrderRepository JsonOrderRepository { get; set; }
    
    [BindProperty]
    public Clients Clients { get; set; }

    public CheckOut(JsonOrderRepository repository)
    {
        JsonOrderRepository = repository;
    }
    
    public IActionResult OnGet()
    {
        return Page();
    }

    public IActionResult OnPost()
    {
        JsonOrderRepository.AddOrder(Clients);
        return RedirectToPage("OrderPage", new { Name = Clients.Name});
    }
}