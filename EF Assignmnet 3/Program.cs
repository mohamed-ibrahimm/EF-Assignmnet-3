using System;
using System.Linq;

namespace EF_Assignment_3.Models
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            using AppDbContext db = new AppDbContext();

            // ---------- (a) Insert a new airline "EgyptAir" ----------
            var egyptAir = db.Airlines.FirstOrDefault(a => a.Name == "EgyptAir");
            if (egyptAir == null)
            {
                egyptAir = new Airline
                {
                    Name = "EgyptAir",
                    ContactPerson = "Ahmed Ali",
                    Address = "Cairo"
                };
                db.Airlines.Add(egyptAir);
                db.SaveChanges();
                Console.WriteLine("Inserted EgyptAir.");
            }
            else Console.WriteLine("EgyptAir already exists.");

            // ---------- (b) Add a new aircraft Model01 capacity 180 to EgyptAir ----------
            var model01 = db.Aircrafts.FirstOrDefault(a => a.Model == "Model01" && a.AirlineId == egyptAir.Id);
            if (model01 == null)
            {
                model01 = new Aircraft
                {
                    Model = "Model01",
                    Capacity = 180,
                    AirlineId = egyptAir.Id
                };
                db.Aircrafts.Add(model01);
                db.SaveChanges();
                Console.WriteLine("Inserted aircraft Model01 (180).");
            }
            else Console.WriteLine("Model01 already exists for EgyptAir.");

            // ---------- (c) Record a new transaction amount 50000 description "Tickets" ----------
            var txn = new Transaction
            {
                Description = "Tickets",
                Amount = 50000m,
                Date = DateTime.UtcNow,
                AirlineId = egyptAir.Id
            };
            db.Transactions.Add(txn);
            db.SaveChanges();
            Console.WriteLine($"Inserted transaction {txn.Description} amount {txn.Amount}.");

            // ---------- (d) Select all employees who work in "EgyptAir" ----------
            var employees = db.Employees.Where(e => e.AirlineId == egyptAir.Id).ToList();
            Console.WriteLine($"Employees in EgyptAir: {employees.Count}");
            foreach (var e in employees) Console.WriteLine($" - {e.Id}: {e.Name}");

            // ---------- (e) Show all transactions (id, description, amount) recorded by "EgyptAir" ----------
            var txns = db.Transactions
                         .Where(t => t.AirlineId == egyptAir.Id)
                         .Select(t => new { t.Id, t.Description, t.Amount })
                         .ToList();
            Console.WriteLine("Transactions for EgyptAir:");
            foreach (var t in txns) Console.WriteLine($"{t.Id} | {t.Description} | {t.Amount}");

            // ---------- (f) Get total number of employees working in each airline ----------
            var counts = db.Airlines
                           .Select(a => new { a.Name, Count = a.Employees.Count() })
                           .ToList();
            Console.WriteLine("Employee counts per airline:");
            foreach (var c in counts) Console.WriteLine($"{c.Name}: {c.Count}");

            // ---------- (g) Change the capacity of "Model01" aircraft to 200 ----------
            var modelToUpdate = db.Aircrafts.FirstOrDefault(a => a.Model == "Model01" && a.AirlineId == egyptAir.Id);
            if (modelToUpdate != null)
            {
                modelToUpdate.Capacity = 200;
                db.SaveChanges();
                Console.WriteLine("Updated Model01 capacity to 200.");
            }

            // ---------- (h) Delete all transactions older than 2020 ----------
            var cutoff = new DateTime(2020, 1, 1);
            var oldTxns = db.Transactions.Where(t => t.Date < cutoff).ToList();
            if (oldTxns.Any())
            {
                db.Transactions.RemoveRange(oldTxns);
                db.SaveChanges();
                Console.WriteLine($"Deleted {oldTxns.Count} transactions older than 2020.");
            }
            else Console.WriteLine("No transactions older than 2020.");

            // ---------- (i) Insert a new route from "Cairo" to "Dubai" ----------
            var route = db.Routes.FirstOrDefault(r => r.Origin == "Cairo" && r.Destination == "Dubai");
            if (route == null)
            {
                route = new Route
                {
                    Origin = "Cairo",
                    Destination = "Dubai",
                    Classification = "International",
                    DistanceKm = 2400
                };
                db.Routes.Add(route);
                db.SaveChanges();
                Console.WriteLine("Inserted route Cairo -> Dubai.");
            }

            // ---------- (j) Assign "Model01" aircraft to Route Cairo->Dubai (duration 4h, price 3000 LE) ----------
            if (modelToUpdate == null)
            {
                modelToUpdate = model01 ?? db.Aircrafts.FirstOrDefault(a => a.Model == "Model01" && a.AirlineId == egyptAir.Id);
            }

            if (modelToUpdate != null && route != null)
            {
                var exists = db.Assignments.Any(a => a.AircraftId == modelToUpdate.Id && a.RouteId == route.Id);
                if (!exists)
                {
                    var assignment = new Assignment
                    {
                        AircraftId = modelToUpdate.Id,
                        RouteId = route.Id,
                        Duration = TimeSpan.FromHours(4),
                        Price = 3000m,
                        Departure = DateTime.UtcNow,
                        Arrival = DateTime.UtcNow.AddHours(4)
                    };
                    db.Assignments.Add(assignment);
                    db.SaveChanges();
                    Console.WriteLine("Assigned Model01 to Cairo->Dubai (4h, 3000 LE).");
                }
                else Console.WriteLine("Assignment already exists.");
            }

            Console.WriteLine("All CRUD operations done. Press any key to exit...");
            Console.ReadKey();
        }
    }
}
