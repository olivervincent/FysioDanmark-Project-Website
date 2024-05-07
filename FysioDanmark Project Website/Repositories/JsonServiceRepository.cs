using FysioDanmark_Project_Website.Interfaces;
using FysioDanmark_Project_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FysioDanmark_Project_Website.Repositories
{
    public class JsonServiceRepository:IServicesRepository
    {
        string JsonFileName = "/Users/olivervincent/Desktop/Zealand/Software Construction/RP_UnSolved-master/RazorPages_Exercises/Book_StoreV10/Book_StoreV10/Data/JsonBooksStore.json";

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
        public Models.Services GetBook(string isbn)
        {
            foreach (var b in GetAllBooks())
            {
                if (b.ISBN == isbn)
                    return b;
            }
            return new Models.Services();
        }
    }
}
