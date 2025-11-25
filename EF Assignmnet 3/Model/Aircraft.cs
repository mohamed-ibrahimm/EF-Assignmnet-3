using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Assignment_3.Models
{
    public class Aircraft
    {
        public int Id { get; set; }
        public string Model { get; set; } = null!;
        public int Capacity { get; set; }

        public int AirlineId { get; set; }
        public Airline Airline { get; set; } = null!;

        public List<Assignment> Assignments { get; set; } = new();
    }
}