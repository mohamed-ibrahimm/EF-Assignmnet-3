using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EF_Assignment_3.Models
{
    public class Airline
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ContactPerson { get; set; } = null!;
        public string Address { get; set; } = null!;

        public List<Phone> Phones { get; set; } = new();
        public List<Aircraft> Aircrafts { get; set; } = new();
        public List<Employee> Employees { get; set; } = new();
        public List<Transaction> Transactions { get; set; } = new();
    }
}