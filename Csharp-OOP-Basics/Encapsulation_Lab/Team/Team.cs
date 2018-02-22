using System;
using System.Collections.Generic;
using System.Text;


public class Team
{
    private string name;
    private List<Person> firstTeam;
    private List<Person> reserveTeam;

    public Team(string Name)
    {
        firstTeam = new List<Person>();
        reserveTeam = new List<Person>();
        name = Name;
    }

    public IReadOnlyCollection<Person> FirstTeam
    {
        get { return this.firstTeam; }
    }

    public IReadOnlyCollection<Person> ReserveTeam
    {
        get { return this.reserveTeam; }
    }

    public void AddPlayer(Person person)
    {
        if (person.Age < 40)
        {
            firstTeam.Add(person);
        }
        else
        {
            reserveTeam.Add(person);
        }
    }
}

