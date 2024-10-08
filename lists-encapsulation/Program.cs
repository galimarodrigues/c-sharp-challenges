﻿using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("How many employees will be registered? ");
        int n = int.Parse(Console.ReadLine());

        List<Employee> employees = new List<Employee>();

        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine($"Employee #{i}:");
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());

            while (employees.Any(e => e.Id == id))
            {
                Console.Write("This ID already exists. Enter another ID: ");
                id = int.Parse(Console.ReadLine());
            }

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Salary: ");
            double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            employees.Add(new Employee(id, name, salary));
            Console.WriteLine();
        }

        Console.Write("Enter the employee id that will have salary increase: ");
        int searchId = int.Parse(Console.ReadLine());

        Employee emp = employees.Find(e => e.Id == searchId);

        if (emp != null)
        {
            Console.Write("Enter the percentage: ");
            double percentage = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            emp.IncreaseSalary(percentage);
        }
        else
        {
            Console.WriteLine("This id does not exist!");
        }

        Console.WriteLine();
        Console.WriteLine("Updated list of employees:");
        foreach (Employee employee in employees)
        {
            Console.WriteLine(employee);
        }
    }
}