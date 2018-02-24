using System;
using System.Collections.Generic;
using System.Text;


public class Animal
{
    private string name;
    private int age;
    private string gender;

    public Animal(string name, int age, string gender)
    {
        Name = name;
        Age = age;
        Gender = gender;
    }
    public string Name
    {
        get => this.name;
        set
        {
            if (string.IsNullOrWhiteSpace(value.Trim()))
            {
                throw new ArgumentException("Invalid input!");
            }
            this.name = value;
        }
    }

    public int Age
    {
        get => this.age;
        set
        {
            if (string.IsNullOrWhiteSpace(value.ToString()) || value<0)
            {
                throw new ArgumentException("Invalid input!");
            }
            this.age = value;
        }
    }

    public string Gender
    {
        get => this.gender;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }
            this.gender = value;
        }
    }

    public static Animal AssignAnimal(string type,string[] animalInfo)
    {
        switch (type)
        {
            case "Dog":
                return new Dog(animalInfo[0],int.Parse(animalInfo[1]),animalInfo[2]);
            case "Cat":
                return new Cat(animalInfo[0], int.Parse(animalInfo[1]), animalInfo[2]);
            case "Kitten":
                animalInfo[2] = "Female";
                return new Kitten(animalInfo[0], int.Parse(animalInfo[1]), animalInfo[2]);
            case "Tomcat":
                animalInfo[2] = "Male";
                return new Tomcat(animalInfo[0], int.Parse(animalInfo[1]), animalInfo[2]);
            case "Frog":
                return new Frog(animalInfo[0], int.Parse(animalInfo[1]), animalInfo[2]);
            default:
                 throw new ArgumentException("Invalid input!");
        }

    }

    public  override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine(this.GetType().Name);
        builder.AppendLine($"{this.Name} {this.Age} {this.Gender}");

        return builder.ToString().Trim();
    }

    public virtual void ProduceSound()
    {

    }
}
