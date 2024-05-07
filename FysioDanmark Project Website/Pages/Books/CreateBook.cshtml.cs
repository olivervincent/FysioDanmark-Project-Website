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

public class CreateBookModel : PageModel
{
    private IBooksRepository repository;
    [BindProperty]
    public Book Book { get; set; }
    public List<Book> Books { get; set; }
    public CreateBookModel(IBooksRepository repo)
    {
        repository = repo;
    }
    public void OnGet()
    {
        Books= repository.GetAllBooks();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        repository.AddBook(Book);
        Books = repository.GetAllBooks();
        return RedirectToPage("CreateBook");           
    }
}