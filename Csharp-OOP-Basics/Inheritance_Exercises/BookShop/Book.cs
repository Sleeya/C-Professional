using System;
using System.Collections.Generic;
using System.Text;


class Book
{
    private string title;
    private string author;
    private decimal price;


    public Book(string author,string title, decimal price)
    {
        Title = title;
        Author = author;
        Price = price;
    }

    public string Title
    {
        get => this.title;
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length<3)
            {
                throw new ArgumentException("Title not valid!");
            }

            title = value;
        }
    }

    public string Author
    {
        get => this.author;
        set
        {
            if (AuthorIsValid(value))
            {
                throw new ArgumentException("Author not valid!");
            }

            this.author = value;
        }
    }

    public virtual decimal Price
    {
        get => this.price;
        set
        {
            if (value<=0)
            {
                throw new ArgumentException("Price not valid!");
            }
            this.price=value;
        }
    }

    private bool AuthorIsValid(string value)
    {
        var secondName = value.Substring(value.IndexOf(" ")+1, value.Length - 1 - value.IndexOf(" "));
        return Char.IsNumber(secondName[0]);
    }

    public override string ToString()
    {
        var resultBuilder = new StringBuilder();
        resultBuilder.AppendLine($"Type: {this.GetType().Name}")
            .AppendLine($"Title: {this.Title}")
            .AppendLine($"Author: {this.Author}")
            .AppendLine($"Price: {this.Price:f2}");

        string result = resultBuilder.ToString().TrimEnd();
        return result;
    }

}

