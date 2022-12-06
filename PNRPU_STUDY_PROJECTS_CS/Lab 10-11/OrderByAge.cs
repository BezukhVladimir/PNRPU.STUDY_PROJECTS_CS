namespace Order;

using System.Collections;
using Figure;
using Staff;

public class OrderByAge : IComparer
{
    public int Compare(object? x, object? y)
    {
        if (x is Rectangle xr)
        {
            if (y is Rectangle yr)
            {
                int diff = (int)(xr.Area - yr.Area);
                
                if (diff > 0)
                    return 1;
                
                if (diff < 0)
                    return -1;
                
                return 0;
            }

            return -1;
        }

        if (y is Rectangle)
        {
            return 1;
        }

        Person first  = x as Person;
        Person second = y as Person;

        if (first != null && second != null)
        {
            if (first.Age == second.Age)
                return 0;
            
            if (first.Age < second.Age)
                return -1;
            
            return 1;
        }

        return -1;
    }
}
