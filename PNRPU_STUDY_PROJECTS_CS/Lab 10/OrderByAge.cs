using Staff;
using System.Collections;
using System.Drawing;

namespace Order;

using Figure;
using Staff;

public class OrderByAge : IComparer
{
    public int Compare(object x, object y)
    {
        if (x is Rectangle xr)
        {
            if (y is Rectangle yr)
            {
                return (int)(xr.Area - yr.Area);
            }

            return -1;
        }

        if (y is Rectangle)
        {
            return 1;
        }

        Person first =  x as Person;
        Person second = y as Person;

        if (first != null && second != null)
        {
            if (first.Age == second.Age)
                return 0;
            else if (first.Age < second.Age)
                return -1;
            else
                return 1;
        }

        return -1;
    }
}
