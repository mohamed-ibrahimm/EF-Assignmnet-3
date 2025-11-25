using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Assignment_3.Models
{
    public class Route
    {
        public int Id { get; set; }
        public string Origin { get; set; } = null!;
        public string Destination { get; set; } = null!;
        public string? Classification { get; set; }
        public double? DistanceKm { get; set; }

        public List<Assignment> Assignments { get; set; } = new();
    }
}