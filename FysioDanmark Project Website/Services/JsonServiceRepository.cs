using FysioDanmark_Project_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FysioDanmark_Project_Website.Data;

namespace FysioDanmark_Project_Website.Services
{
    public class JsonServiceRepository
    {
        string JsonFileName= new Paths().JsonServicesPath;

        public List<Models.Services> GetAllServices()
        {
            return JsonFileReader.ReadJsonService(JsonFileName);
        }
        public void AddService(Models.Services services)
        {
            List<Models.Services> serviceList = GetAllServices().ToList();
            serviceList.Add(services);
            JsonFileWritter.WriteToJsonService(serviceList, JsonFileName);
        }
    }
}
