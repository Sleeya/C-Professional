using System;
using System.Collections.Generic;
using System.Text;


public class FoodFactory
{
  

    public static Food ProduceFoodObject(string food)
    {


        switch (food.ToLower())
        {
            case "cram":
                return new Cram();
            case "lembas":
                return new Lembas();
            case "apple":
                return new Apple();
            case "melon":
                return new Melon();
            case "honeycake":
                return new HoneyCake();
            case "mushrooms":
                return new Mushroom();
            default:
                return new JunkFood();
        }
    }
}
