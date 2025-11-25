using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Assignment_3.Models
{
    public class Assignment
    {
        public int Id { get; set; }

        public int AircraftId { get; set; }
        public Aircraft Aircraft { get; set; } = null!;

        public int RouteId { get; set; }
        public Route Route { get; set; } = null!;

        public int? NumOfPassengers { get; set; }
        public decimal? Price { get; set; }
        public DateTime? Departure { get; set; }
        public DateTime? Arrival { get; set; }
        public TimeSpan? Duration { get; set; }
    }
}