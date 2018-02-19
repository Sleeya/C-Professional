using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

class PriceCalculator
{
    private decimal pricePerDay;
    private int numberOfDays;
    private SeasonEnum season;
    private DiscountEnum discountType;

    public PriceCalculator(string input)
    {
       string[] tokens = input.Split().ToArray();

        pricePerDay = decimal.Parse(tokens[0]);
        numberOfDays = int.Parse(tokens[1]);
        season = Enum.Parse<SeasonEnum>(tokens[2]);
        discountType = DiscountEnum.None;
        if (tokens.Length > 3)
        {
            discountType = Enum.Parse<DiscountEnum>(tokens[3]);
        }
    }

    public void  Calculate()
    {
        var priceBeforeDiscount = (pricePerDay * (int)season) * numberOfDays;
        var priceAfterDiscount = (decimal)priceBeforeDiscount * (1-((decimal)discountType/100));
        Console.WriteLine($"{priceAfterDiscount:f2}");
    }
}

