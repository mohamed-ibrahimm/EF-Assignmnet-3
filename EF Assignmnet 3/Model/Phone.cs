using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Assignment_3.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;

        public int AirlineId { get; set; }
        public Airline Airline { get; set; } = null!;
    }
}
