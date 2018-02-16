using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        int numberOfEmployees = int.Parse(Console.ReadLine());
        var employeeList = new List<Employee>();
        for (int i = 0; i < numberOfEmployees; i++)
        {
            var input = Console.ReadLine().Split().ToArray();
            string name = input[0];
            decimal salary = decimal.Parse(input[1]);
            string position = input[2];
            string department = input[3];


            Employee currentEmployee = new Employee(name, salary, position, department);
            

            if (input.Length >= 5)
            {
                int num;
                if (int.TryParse(input[4], out num))
                {
                    currentEmployee.Age = int.Parse(input[4]);
                    if (input.Length == 6)
                    {
                        currentEmployee.Email = input[5];
                    }
                }
                else
                {
                    currentEmployee.Email = input[4];
                    if (input.Length == 6)
                    {
                        currentEmployee.Age = int.Parse(input[5]);
                    }
                }
                
            }
            employeeList.Add(currentEmployee);
        }

        var result = employeeList.GroupBy(x => x.Department).Select(x => new
        {
            Department = x.Key,
            AverageSalary = x.Average(y => y.Salary),
            EmployeeList = x.OrderByDescending(d => d.Name)
        })
            .OrderByDescending(dep => dep.AverageSalary).FirstOrDefault();

        Console.WriteLine($"Highest Average Salary: {result.Department}");

        foreach (var res in result.EmployeeList.OrderByDescending(x=>x.Salary))
        {
            Console.WriteLine($"{res.Name} {res.Salary:f2} {res.Email} {res.Age}");
        }
    }
}

