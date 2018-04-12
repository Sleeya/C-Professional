

namespace WorkForce.Models.Employees
{
    public abstract class Employee
    {
        private string name;
        private int weeklyWorkHours;

        protected Employee(string name, int weeklyWorkHours)
        {
            this.Name = name;
            this.WeeklyWorkHours = weeklyWorkHours;
        }

        public string Name
        {
            get => this.name;
            protected set => this.name = value;
        }

        public int WeeklyWorkHours
        {
            get => this.weeklyWorkHours;
            protected set => this.weeklyWorkHours = value;
        }
    }
}
