namespace UserInputHandler;

class Number
{
    public static double Get()
    {
        double enteredNumber;

        while (!double.TryParse(Console.ReadLine(), out enteredNumber))
        {
            Console.Write("This is not valid input. Please enter a number: ");
        }

        return enteredNumber;
    }

    public static double GetExcluding(double[] excludedNumbers)
    {
        double enteredNumber;
        bool isExcludedNumber = false;

        while (true)
        {
            enteredNumber = Get();

            foreach (double excludedNumber in excludedNumbers)
            {
                if (enteredNumber == excludedNumber)
                {
                    Console.Write("This number is excluded. Please enter a another number: ");
                    isExcludedNumber = true;
                    break;
                }

                isExcludedNumber = false;
            }

            if (!isExcludedNumber)
                break;
        }

        return enteredNumber;
    }

    public static void GetRange(out double from, out double to)
    {
        while (true)
        {
            Console.WriteLine("\nУкажите целочисленный диапазон [от; до]:");
            Console.Write("от — "); from = Get();
            Console.Write("до — "); to   = Get();

            if (from <= to)
                break;

            Console.WriteLine($"Error: range is empty [{from}; {to}], from > to");
        }

        Console.WriteLine($"Вы указали диапазон [{from}; {to}]");
    }

    public static double GetFromRange(double from = double.MinValue,
                                      double to   = double.MaxValue)
    {
        if (from > to)
            throw new Exception($"Error: range is empty [{from}; {to}], from > to");

        double enteredNumber;

        while (true)
        {
            enteredNumber = Get();

            if (from <= enteredNumber && enteredNumber <= to)
                return enteredNumber;
            else
                Console.Write($"This number is not in a range [{from}; {to}].\nPlease enter a another number: ");
        }
    }
}

class Integer
{
    public static int Get()
    {
        int enteredInteger;

        while (!Int32.TryParse(Console.ReadLine(), out enteredInteger))
        {
            Console.Write("This is not valid input. Please enter a integer: ");
        }

        return enteredInteger;
    }

    public static void GetRange(out int from, out int to)
    {
        while (true)
        {
            Console.WriteLine("\nУкажите целочисленный диапазон [от; до]:");
            Console.Write("от — "); from = Get();
            Console.Write("до — ");   to = Get();

            if (from <= to)
                break;

            Console.WriteLine($"Error: range is empty [{from}; {to}], from > to");
        }

        Console.WriteLine($"Вы указали диапазон [{from}; {to}]");
    }

    public static int GetFromRange(int from = int.MinValue, int to = int.MaxValue)
    {
        if (from > to)
            throw new Exception($"Error: range is empty [{from}; {to}], from > to");

        int enteredInteger;

        while (true)
        {
            enteredInteger = Get();

            if (from <= enteredInteger && enteredInteger <= to)
                return enteredInteger;
            else
                Console.Write($"This integer is not in a range [{from}; {to}].\nPlease enter a another integer: ");
        }
    }
}

class String
{
    public static string? Get()
    {
        Console.Write("\nВведите строку: ");
        return Console.ReadLine();
    }

    public static string? GetAccordingTo(string[] checklist)
    {
        while (true)
        {
            Console.Write("Введите строку: ");
            string? input = Console.ReadLine();

            foreach (string validLine in checklist)
            {
                if (input == validLine)
                    return input;
            }

            Console.WriteLine("Введённая строка некорректна, попробуйте ещё раз.");
        }
    }
}