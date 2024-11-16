using System;
using System.Collections.Generic;
using System.Linq;

class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public int DepId { get; set; }
}

class Department
{
    public int Id { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
}

class Program
{
    static void Main()
    {
        List<Department> departments = new List<Department>()
        {
            new Department(){ Id = 1, Country = "Ukraine", City = "Lviv" },
            new Department(){ Id = 2, Country = "Ukraine", City = "Kyiv" },
            new Department(){ Id = 3, Country = "France", City = "Paris" },
            new Department(){ Id = 4, Country = "Ukraine", City = "Odesa" }
        };

        List<Employee> employees = new List<Employee>()
        {
            new Employee() { Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 22, DepId = 2 },
            new Employee() { Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepId = 1 },
            new Employee() { Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepId = 3 },
            new Employee() { Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2 },
            new Employee() { Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepId = 4 },
            new Employee() { Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age = 22, DepId = 2 },
            new Employee() { Id = 7, FirstName = "Nikita", LastName = "Krotov", Age = 27, DepId = 4 }
        };

        var employeesInUkraineButNotInOdesa = from emp in employees
                                              join dep in departments on emp.DepId equals dep.Id
                                              where dep.Country == "Ukraine" && dep.City != "Odesa"
                                              select new { emp.FirstName, emp.LastName };

        Console.WriteLine("Employees in Ukraine, but not in Odesa:");
        foreach (var emp in employeesInUkraineButNotInOdesa)
        {
            Console.WriteLine($"{emp.FirstName} {emp.LastName}");
        }

        var uniqueCountries = departments.Select(dep => dep.Country).Distinct().ToList();

        Console.WriteLine("\nUnique countries:");
        foreach (var country in uniqueCountries)
        {
            Console.WriteLine(country);
        }

        var first3EmployeesOver25 = employees.Where(emp => emp.Age > 25).Take(3).ToList();

        Console.WriteLine("\nFirst 3 employees older than 25:");
        foreach (var emp in first3EmployeesOver25)
        {
            Console.WriteLine($"{emp.FirstName} {emp.LastName}, Age: {emp.Age}");
        }

        var employeesInKyivOver23 = from emp in employees
                                    join dep in departments on emp.DepId equals dep.Id
                                    where dep.City == "Kyiv" && emp.Age > 23
                                    select new { emp.FirstName, emp.LastName, emp.Age };

        Console.WriteLine("\nEmployees in Kyiv, older than 23:");
        foreach (var emp in employeesInKyivOver23)
        {
            Console.WriteLine($"{emp.FirstName} {emp.LastName}, Age: {emp.Age}");
        }
    }
}
