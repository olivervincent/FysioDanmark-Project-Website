using FysioDanmark_Project_Website.Interfaces;
using FysioDanmark_Project_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FysioDanmark_Project_Website.Repositories
{
    public class JsonBookRepository:IBooksRepository
    {
        string JsonFileName = "/Users/olivervincent/Desktop/Zealand/Software Construction/RP_UnSolved-master/RazorPages_Exercises/Book_StoreV10/Book_StoreV10/Data/JsonBooksStore.json";

        public List<Book> GetAllBooks()
        {
            return JsonFileReader.ReadJsonBook(JsonFileName);
        }
        public void AddBook(Book book)
        {
            List<Book> books = GetAllBooks().ToList();
            books.Add(book);
            JsonFileWritter.WriteToJsonBook(books, JsonFileName);
        }
        public Book GetBook(string isbn)
        {
            foreach (var b in GetAllBooks())
            {
                if (b.ISBN == isbn)
                    return b;
            }
            return new Book();
        }
    }
}
