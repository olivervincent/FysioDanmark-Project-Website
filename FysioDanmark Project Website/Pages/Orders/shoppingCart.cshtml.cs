using FysioDanmark_Project_Website.Interfaces;
using FysioDanmark_Project_Website.Models;
using FysioDanmark_Project_Website.Repositories;
using FysioDanmark_Project_Website.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FysioDanmark_Project_Website;

public class shoppingCart : PageModel
{
    [BindProperty]
    public Book Book { get; set; }
    public double TotalPrice { get; set; }
    private Repositories.JsonBookRepository repo;
    public ShoppingCartService ShoppingCartService { get; set; }
    
    public shoppingCart(Repositories.JsonBookRepository repository, ShoppingCartService shoppingCartService)
    {
        repo = repository;
        ShoppingCartService = shoppingCartService;
    }

    public IActionResult OnPost(string ISBN)
    {
        Book = repo.GetBook(ISBN);
        ShoppingCartService.RemoveBookFromCart(Book);
        return Page();
    }
    
    public IActionResult OnGet(string ISBN)
    {
        if (ISBN != null)
        {
            Book = repo.GetBook(ISBN);
            ShoppingCartService.AddToCart(Book);
        }
        TotalPrice = ShoppingCartService.CalcTotalPrice();
        return Page();
    }
}