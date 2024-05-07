using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FysioDanmark_Project_Website.Models
{
    public class Order
    {     
        public int OrderId { get; set; }          
        public Student Student { get; set; }
        public List<Book> Books { get; set; }
        public DateTime DateTime { get; set; }
    }
}
