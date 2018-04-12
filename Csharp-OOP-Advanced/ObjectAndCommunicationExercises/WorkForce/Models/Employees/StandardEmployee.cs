

namespace WorkForce.Models.Employees
{
    public class StandardEmployee:Employee
    {
        private const int setWeeklyWorkHours = 40;

        public StandardEmployee(string name) : base(name, setWeeklyWorkHours)
        {
        }
    }
}
