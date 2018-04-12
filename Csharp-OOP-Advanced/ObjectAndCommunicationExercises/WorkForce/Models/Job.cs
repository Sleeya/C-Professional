using System;
using WorkForce.Models.Employees;

namespace WorkForce.Models
{
    public class Job
    {
        private string name;
        private int hoursOfWorkRequired;
        private Employee employee;

        public Job(string name, int hoursOfWorkRequired, Employee employee)
        {
            this.Name = name;
            this.HoursOfWorkRequired = hoursOfWorkRequired;
            this.Employee = employee;
        }

        public event EventHandler<JobDoneEventArgs> JobDone;

        public string Name
        {
            get => this.name;
            private set => this.name = value;
        }

        public int HoursOfWorkRequired
        {
            get => this.hoursOfWorkRequired;
            private set => this.hoursOfWorkRequired = value;
        }

        public Employee Employee
        {
            get => this.employee;
            private set => this.employee = value;
        }

        public void Update()
        {
            this.HoursOfWorkRequired -= this.Employee.WeeklyWorkHours;

            if (this.HoursOfWorkRequired <= 0)
            {
                this.JobDone?.Invoke(this, new JobDoneEventArgs(this));
            }
        }

        public override string ToString()
        {
            return $"Job: {this.Name} Hours Remaining: {this.HoursOfWorkRequired}";
        }
    }
}
