using FysioDanmark_Project_Website.Interfaces;
using FysioDanmark_Project_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FysioDanmark_Project_Website.Data;

namespace FysioDanmark_Project_Website.Repositories
{
    public class JsonServiceRepository:IServicesRepository
    {
        string JsonServicePath = new Paths().JsonServicesPath;

        public List<Models.Services> GetAllServices()
        {
            return JsonFileReader.ReadJsonService(JsonServicePath);
        }
        public void AddService(Models.Services service)
        {
            List<Models.Services> serviceList = GetAllServices().ToList();
            serviceList.Add(service);
            JsonFileWritter.WriteToJsonService(serviceList, JsonServicePath);
        }

        public void DeleteService(int id)
        {
            List<Models.Services> serviceList = GetAllServices();
            serviceList.RemoveAll(service => service.Id == id);;
            JsonFileWritter.WriteToJsonService(serviceList, JsonServicePath);
        }

        public void UpdateService(Models.Services service)
        {
            if (service != null)
            {
                List<Models.Services> servicesList = JsonFileReader.ReadJsonService(JsonServicePath);
                servicesList.RemoveAll(s => s.Id == service.Id);
                servicesList.Add(service);
                JsonFileWritter.WriteToJsonService(servicesList, JsonServicePath);
            }
        }
        public Models.Services GetService(int id)
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
