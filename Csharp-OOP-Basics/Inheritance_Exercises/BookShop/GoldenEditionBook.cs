using System;
using System.Collections.Generic;
using System.Text;


class GoldenEditionBook : Book
{

    public GoldenEditionBook(string title, string author, decimal price) : base(title, author, price)
    {

    }

    public override decimal Price
    {
        get => base.Price;
        set => base.Price = value * (decimal)1.3;
    }
}
