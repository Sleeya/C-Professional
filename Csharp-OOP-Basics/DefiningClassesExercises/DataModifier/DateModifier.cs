using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;


public class DateModifier
{
    public double CalcDifference(string paramOne, string paramTwo)
    {
        var firstDate = DateTime.ParseExact(paramOne, "yyyy MM dd", CultureInfo.InvariantCulture);
        var secondDate = DateTime.ParseExact(paramTwo, "yyyy MM dd", CultureInfo.InvariantCulture);

        return Math.Round(Math.Abs((firstDate - secondDate).TotalDays));
    }
}
