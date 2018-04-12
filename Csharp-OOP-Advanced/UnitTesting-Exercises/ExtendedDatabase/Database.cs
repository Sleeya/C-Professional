using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Database
{
    private List<Person> people;

    public Database()
    {
        this.people = new List<Person>();
    }

    public void Add(Person person)
    {
        if (this.people.Any(x=>x.Username == person.Username))
        {
            throw new InvalidOperationException($"User with username {person.Username} already exists.");
        }

        if (this.people.Any(x=>x.Id == person.Id))
        {
            throw new InvalidOperationException($"User with id {person.Id} already exists.");
        }
        this.people.Add(person);
    }

    public void Remove()
    {
        if (this.people.Count<=0)
        {
            throw new InvalidOperationException("Database is already empty.");
        }
        this.people.RemoveAt(people.Count-1);
    }

    public Person FindByUsername(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            throw new ArgumentNullException();
        }

        if (!this.people.Any(x=>x.Username == username))
        {
            throw new InvalidOperationException($"User with username {username} doesn't exists.");
        }

        return this.people.Find(x => x.Username == username);
    }

    public Person FindById(long id)
    {
        if (id < 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        if (!this.people.Any(x => x.Id == id))
        {
            throw new InvalidOperationException($"User with id {id} doesn't exists.");
        }

        return this.people.Find(x => x.Id == id);
    }




}

