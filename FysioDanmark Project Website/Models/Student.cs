using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FysioDanmark_Project_Website.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Section Section { get; set; }
    }
}
