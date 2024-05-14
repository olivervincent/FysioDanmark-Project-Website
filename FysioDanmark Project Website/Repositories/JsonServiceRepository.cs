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
        string JsonFileName = "/Users/olivervincent/Desktop/Zealand/FysioDanmark Project Website/FysioDanmark Project Website/Data/JsonServices.json";

        public List<Models.Services> GetAllServices()
        {
            return JsonFileReader.ReadJsonService(JsonFileName);
        }
        public void AddService(Models.Services service)
        {
            List<Models.Services> serviceList = GetAllServices().ToList();
            serviceList.Add(service);
            JsonFileWritter.WriteToJsonService(serviceList, JsonFileName);
        }

        public void DeleteService(Models.Services service)
        {
            List<Models.Services> serviceList = GetAllServices();
            serviceList.Remove(service);
            JsonFileWritter.WriteToJsonService(serviceList, JsonFileName);
        }
        public Models.Services GetService(string id)
        {
            foreach (var b in GetAllServices())
            {
                if (b.Id == id)
                    return b;
            }
            return new Models.Services();
        }
    }
}
