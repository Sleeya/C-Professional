using System;


class Program
{
    static void Main(string[] args)
    {
        try
        {
            var pizzaInfo = Console.ReadLine().Split();
            var doughInfo = Console.ReadLine().Split();
            Dough currentDought = new Dough(flourType: doughInfo[1], bakingTechnique: doughInfo[2], weight: double.Parse(doughInfo[3]));

            Pizza currentPizza = new Pizza(name: pizzaInfo[1], dough: currentDought);
            var toppingInfo = new string[3];
            while ((toppingInfo = Console.ReadLine().Split())[0] != "END")
            {
                Topping currentTopping = new Topping(type: toppingInfo[1], weight: double.Parse(toppingInfo[2]));
                currentPizza.AddToppings(currentTopping);
            }

            Console.WriteLine($"{currentPizza.Name} - {currentPizza.CalcTotalCalories():f2} Calories.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
}

