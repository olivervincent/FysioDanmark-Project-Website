using FysioDanmark_Project_Website.Models;
using FysioDanmark_Project_Website.Repositories;
using FysioDanmark_Project_Website.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FysioDanmark_Project_Website;

public class BookingPage : PageModel
{
    public double TotalPrice { get; set; }
    public string StudentName { get; set; }
    public ShoppingCartService ShoppingCartService { get; set; }
    
    public BookingPage(ShoppingCartService shoppingCartService)
    {
        ShoppingCartService = shoppingCartService;
    }
    
    public IActionResult OnGet(string Name)
    {
        StudentName = Name;
        TotalPrice = ShoppingCartService.CalcTotalPrice();
        return Page();
    }
}