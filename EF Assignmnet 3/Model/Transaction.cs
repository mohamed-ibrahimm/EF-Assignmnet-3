using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Assignment_3.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public int AirlineId { get; set; }
        public Airline Airline { get; set; } = null!;
    }
}