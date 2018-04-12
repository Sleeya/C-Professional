using System;
using System.Collections.Generic;
using System.Linq;
using WorkForce.Models;
using WorkForce.Models.Employees;

namespace WorkForce
{
    class StartUp
    {
        static void Main(string[] args)
        {
            JobList jobs = new JobList();
            List<Employee> employees  = new List<Employee>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                var input = command.Split();
                var type = input[0];

                switch (type)
                {
                    case "Job":
                        AddNewJob(jobs, employees, input);
                        break;
                    case "StandardEmployee":
                        AddStandardEmployee(employees, input);
                        break;
                    case "PartTimeEmployee":
                        AddPartTimeEmployee(employees, input);
                        break;
                    case "Pass":
                        UpdateJobs(jobs);
                        break;
                    case "Status":
                        GetStatus(jobs);
                        break;
                }
            }
        }

        private static void AddNewJob(JobList jobs, List<Employee> employees, string[] input)
        {
            var nameOfJob = input[1];
            var hoursOfWorkRequired = int.Parse(input[2]);
            var employeeName = input[3];
            var employee = employees.FirstOrDefault(x => x.Name == employeeName);
            Job job = new Job(nameOfJob, hoursOfWorkRequired, employee);
            job.JobDone += jobs.OnJobeDone;
            jobs.Add(job);
        }

        private static void AddStandardEmployee(List<Employee> employees, string[] input)
        {
            var standartEmployeeName = input[1];
            employees.Add(new StandardEmployee(standartEmployeeName));
        }

        private static void AddPartTimeEmployee(List<Employee> employees, string[] input)
        {
            var partTimeEmployeeName = input[1];
            employees.Add(new PartTimeEmployee(partTimeEmployeeName));
        }

        private static void UpdateJobs(JobList jobs)
        {
            foreach (var currentJob in jobs.ToArray())
            {
                currentJob.Update();
            }
        }

        private static void GetStatus(JobList jobs)
        {
            foreach (var currentJob in jobs)
            {
                Console.WriteLine(currentJob);
            }
        }
    }
}
