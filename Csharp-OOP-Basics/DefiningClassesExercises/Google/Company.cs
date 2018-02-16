using System;
using System.Collections.Generic;
using System.Text;


class Company
{
    private string name;
    private string department;
    private decimal salary;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public string Department
    {
        get { return this.department; }
        set { this.department = value; }
    }

    public decimal Salary
    {
        get { return this.salary; }
        set { this.salary = value; }
    }
}

