using FysioDanmark_Project_Website.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace FysioDanmark_Project_Website
{
    public class JsonFileReader
    {
        public static List<Models.Services> ReadJsonBook(string JsonFileName)
        {
            string jsonString = File.ReadAllText(JsonFileName);

            return JsonSerializer.Deserialize<List<Models.Services>>(jsonString);
        }
        
        public static List<Bookings> ReadJsonOrder(string JsonFileName)
        {
            string jsonString = File.ReadAllText(JsonFileName);

            return JsonSerializer.Deserialize<List<Bookings>>(jsonString);
        }
    }
}
