
namespace WorkForce.Models.Employees
{
    public class PartTimeEmployee:Employee
    {
        private const int setWeeklyWorkHours = 20;

        public PartTimeEmployee(string name) : base(name, setWeeklyWorkHours)
        {
        }
    }
}
