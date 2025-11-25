using EF_Assignment_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Assignment_3.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? Birthday { get; set; }
        public string? Position { get; set; }
        public string? Gender { get; set; }

        public int AirlineId { get; set; }
        public Airline Airline { get; set; } = null!;
    }
}
