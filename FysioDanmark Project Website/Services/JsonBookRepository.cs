using FysioDanmark_Project_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FysioDanmark_Project_Website.Services
{
    public class JsonBookRepository
    {
        string JsonFileName= "/Users/olivervincent/Desktop/Zealand/Software Construction/RP_UnSolved-master/RazorPages_Exercises/Book_StoreV10/Book_StoreV10/Data/JsonBooksStock.json";

        public List<Models.Services> GetAllBooks()
        {
            return JsonFileReader.ReadJsonBook(JsonFileName);
        }
        public void AddBook(Models.Services services)
        {
            List<Models.Services> books = GetAllBooks().ToList();
            books.Add(services);
            JsonFileWritter.WriteToJsonBook(books, JsonFileName);
        }
    }
}
