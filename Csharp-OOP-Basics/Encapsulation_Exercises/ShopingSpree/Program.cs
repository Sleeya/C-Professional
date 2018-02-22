using System;
using System.Collections.Generic;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {

        try
        {
            var peopleInput = Console.ReadLine().Split(";");
            List<Person> people = new List<Person>();
            for (int i = 0; i < peopleInput.Length; i++)
            {
                var personInfo = peopleInput[i].Split("=");
                Person currentPerson = new Person(name: personInfo[0], money: decimal.Parse(personInfo[1]));
                people.Add(currentPerson);
            }

            var productInput = Console.ReadLine().TrimEnd(';').Split(";");
            List<Product> products = new List<Product>();
            for (int i = 0; i < productInput.Length; i++)
            {
                var productInfo = productInput[i].Split("=");
                Product currentProduct = new Product(name: productInfo[0], cost: decimal.Parse(productInfo[1]));
                products.Add(currentProduct);
            }

            var command = string.Empty;
            while ((command=Console.ReadLine())!= "END")
            {
                var splitInfo = command.Split();

                var currentPerson = people.Where(x => x.Name == splitInfo[0]).First();
                var currentProduct = products.Where(x => x.Name == splitInfo[1]).First();
                currentPerson.BuyProduct(currentProduct);
            }
            foreach (var person in people)
            {
                if (person.BagOfProducts.Count>0)
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.BagOfProducts.Select(x=>x.Name))}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }

       
    }
}

