using System;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;

namespace PusulaTalentAcademyDocumentCandidate
{
    public class FilterEmployeesClass
    {
        public static string FilterEmployees(IEnumerable<(string Name, int Age, string Department, decimal Salary, DateTime HireDate)> employees)
        {
            var filtered = employees
                .Where(p => p.Age >= 25 && p.Age <= 40
                            && p.Department == "IT" || p.Department == "Finance" 
                            && p.Salary >= 5000 && p.Salary <= 9000
                            && p.HireDate >= new DateTime(2017, 1, 1))
                .ToList();

            var names = filtered.Select(p => p.Name).OrderBy(n => n).ToList();

            decimal totalSalary = filtered.Any() ? filtered.Sum(p => p.Salary) : 0;
            decimal averageSalary = filtered.Any() ? Math.Round(filtered.Average(p => p.Salary), 2) : 0;
            decimal minSalary = filtered.Any() ? filtered.Min(p => p.Salary) : 0;
            decimal maxSalary = filtered.Any() ? filtered.Max(p => p.Salary) : 0;
            int count = filtered.Count;

            var result = new
            {
                Names = names,
                TotalSalary = totalSalary,
                AverageSalary = averageSalary,
                MinSalary = minSalary,
                MaxSalary = maxSalary,
                Count = count
            };

            return JsonSerializer.Serialize(result);
        }

        public static void Main()
        {
            var employees1 = new List<(string Name, int Age, string Department, decimal Salary, DateTime HireDate)>
            {
                ("Ali", 30, "IT", 6000m, new DateTime(2018, 5, 1)),
                ("Ayşe", 35, "Finance", 8500m, new DateTime(2019, 3, 15)),
                ("Veli", 28, "IT", 7000m, new DateTime(2020, 1, 1))
            };
            Console.WriteLine("Çıkış 1: " + FilterEmployees(employees1));

            var employees2 = new List<(string Name, int Age, string Department, decimal Salary, DateTime HireDate)>
            {
                ("Mehmet", 26, "Finance", 5000m, new DateTime(2021, 7, 1)),
                ("Zeynep", 39, "IT", 9000m, new DateTime(2018, 11, 20))
            };
            Console.WriteLine("Çıkış 2: " + FilterEmployees(employees2));

            var employees3 = new List<(string Name, int Age, string Department, decimal Salary, DateTime HireDate)>
            {
                ("Burak", 41, "IT", 6000m, new DateTime(2018, 6, 1))
            };
            Console.WriteLine("Çıkış 3: " + FilterEmployees(employees3));

            var employees4 = new List<(string Name, int Age, string Department, decimal Salary, DateTime HireDate)>
            {
                ("Canan", 29, "Finance", 8000m, new DateTime(2019, 9, 1)),
                ("Okan", 35, "IT", 7500m, new DateTime(2020, 5, 10))
            };
            Console.WriteLine("Çıkış 4: " + FilterEmployees(employees4));

            var employees5 = new List<(string Name, int Age, string Department, decimal Salary, DateTime HireDate)>
            {
                ("Elif", 27, "Finance", 6500m, new DateTime(2017, 12, 31))
            };
            Console.WriteLine("Çıkış 5: " + FilterEmployees(employees5));
        }
    }
}
