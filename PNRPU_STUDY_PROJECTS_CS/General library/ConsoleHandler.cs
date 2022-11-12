namespace ConsoleHandler;

class Cleaner
{
    public static void ClearRowsInRange(int from, int to)
    {
        if (from < 0)
            throw new Exception($"Error: from < 0");

        if (to < 0)
            throw new Exception($"Error: to < 0");

        if (from > to)
            throw new Exception($"Error: range is empty [{from}; {to}], from > to");

        while (from <= to)
        {
            Console.SetCursorPosition(0, to);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, to);
            --to;
        }
    }
}
