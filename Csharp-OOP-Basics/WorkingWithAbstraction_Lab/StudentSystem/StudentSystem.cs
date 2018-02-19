using System;
using System.Collections.Generic;
using System.Text;

public class StudentSystem
{
    private Dictionary<string, Student> repo;

    public StudentSystem()
    {
        this.Repo = new Dictionary<string, Student>();
    }

    public Dictionary<string, Student> Repo
    {
        get { return repo; }
        private set { repo = value; }
    }

    public void ParseCommand(string command)
    {
        string[] args = command.Split();

        if (args[0] == "Create")
        {
            CreateStudent(args);
        }
        else if (args[0] == "Show")
        {
            ShowStudent(args);

        }
    }

    private void ShowStudent(string[] args)
    {
        var name = args[1];
        if (Repo.ContainsKey(name))
        {
            var student = Repo[name];
            string view = $"{student.Name} is {student.Age} years old.";

            if (student.Grade >= 5.00)
            {
                view += " Excellent student.";
            }
            else if (student.Grade < 5.00 && student.Grade >= 3.50)
            {
                view += " Average student.";
            }
            else
            {
                view += " Very nice person.";
            }

            Console.WriteLine(view);
        }
    }

    private void CreateStudent(string[] args)
    {
        var name = args[1];
        var age = int.Parse(args[2]);
        var grade = double.Parse(args[3]);
        if (!repo.ContainsKey(name))
        {
            var student = new Student(name, age, grade);
            Repo[name] = student;
        }
    }
}

