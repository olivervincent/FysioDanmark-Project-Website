using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using FysioDanmark_Project_Website.Models;

namespace FysioDanmark_Project_Website
{
    public class JsonFileWritter
    {
        public static void WriteToJsonService(List<Models.Services> books, string JsonFileName)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(books, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(JsonFileName, output);
        }
        
        public static void WriteToJsonBooking(List<Bookings> orders, string JsonFileName)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(orders, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(JsonFileName, output);
        }
        
        public static void WriteToJsonStaff(List<Staff> staff, string JsonFileName)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(staff, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(JsonFileName, output);
        }
    }
}
