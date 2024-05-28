using FysioDanmark_Project_Website.Interfaces;
using FysioDanmark_Project_Website.Models;
using FysioDanmark_Project_Website.Repositories;
using FysioDanmark_Project_Website.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FysioDanmark_Project_Website;

public class ShoppingCart : PageModel
{
    [BindProperty]
    public Models.Services Services { get; set; }
    public double TotalPrice { get; set; }
    private Repositories.JsonServiceRepository repo;
    public ShoppingCartService ShoppingCartService { get; set; }
    
    public ShoppingCart(Repositories.JsonServiceRepository repository, ShoppingCartService shoppingCartService)
    {
        repo = repository;
        ShoppingCartService = shoppingCartService;
    }

    public IActionResult OnPost(int Id)
    {
        Services = repo.GetService(Id);
        ShoppingCartService.RemoveServiceFromCart(Services);
        TotalPrice = ShoppingCartService.CalcTotalPrice();
        return Page();
    }
    
    public IActionResult OnGet(int Id)
    {
        if (Id != null)
        {
            Services = repo.GetService(Id);
            ShoppingCartService.AddToCart(Services);
        }
        TotalPrice = ShoppingCartService.CalcTotalPrice();
        return Page();
    }
}