using FysioDanmark_Project_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FysioDanmark_Project_Website.Models;

namespace FysioDanmark_Project_Website.Interfaces
{
    public interface IBooksRepository
    {
        List<Book> GetAllBooks();
        void AddBook(Book book);
        Book GetBook(string isbn);
    }
}
