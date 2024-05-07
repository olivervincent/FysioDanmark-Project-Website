using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FysioDanmark_Project_Website.Models
{
    public class Bookings
    {     
        public int BookingId { get; set; }          
        public Clients Clients { get; set; }
        public List<Services> Services { get; set; }
        public DateTime DateTime { get; set; }
        public Staff Staff { get; set; }
    }
}
