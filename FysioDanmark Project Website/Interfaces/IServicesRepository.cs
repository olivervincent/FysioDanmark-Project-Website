﻿using FysioDanmark_Project_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FysioDanmark_Project_Website.Models;

namespace FysioDanmark_Project_Website.Interfaces
{
    public interface IServicesRepository
    {
        List<Models.Services> GetAllServices();
        void AddService(Models.Services services);
        Models.Services GetService(string isbn);
        void DeleteService(Models.Services service);
    }
}