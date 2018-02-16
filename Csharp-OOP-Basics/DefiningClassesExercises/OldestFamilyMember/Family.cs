using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Family
{
    private List<Person> people;

    public Family()
    {
        this.people = new List<Person>();
    }

    public void AddMember(Person member)
    {
       
        people.Add(member);
    }

    public Person GetOldestMember()
    {
        Person oldest = new Person();
        oldest = this.people.Find(x => x.Age == this.people.Max(y => y.Age));
        return oldest;

    }

}
