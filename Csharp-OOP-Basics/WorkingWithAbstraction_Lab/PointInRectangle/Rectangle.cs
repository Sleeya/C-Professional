using System;
using System.Collections.Generic;
using System.Text;

class Rectangle
{
    public Point topLeft { get; set; }
    public Point bottomRight { get; set; }

    public Rectangle(Point topLeft, Point bottomRight)
    {
        this.topLeft = topLeft;
        this.bottomRight = bottomRight;
    }

    public bool ContainsPoint(Point point)
    {
        if (point.X >= topLeft.X && point.X <= bottomRight.X && point.Y >= topLeft.Y && point.Y <= bottomRight.Y)
        {
            return true;
        }
        return false;
    }


}
