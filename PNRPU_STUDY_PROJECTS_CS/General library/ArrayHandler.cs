namespace ArrayHandler;

using SpecificDataStructures;

class OneDimensional
{
    // integer
    public static void Fill(int[] array)
    {
        Console.WriteLine("\nСпособы заполнения одномерного массива:");
        Console.WriteLine("0) отменить заполнение массива;");
        Console.WriteLine("1) заполнить вручную с клавиатуры;");
        Console.WriteLine("2) сгенерировать случайные значения.");
        Console.Write("Для продолжения введите номер опции: ");

        int menuOptionNumber = UserInputHandler.Integer.GetFromRange(0, 2);

        switch (menuOptionNumber)
        {
            case 0:
                return;
            case 1:
                KeyboardInput(array);
                break;
            case 2:
                int from, to;
                UserInputHandler.Integer.GetRange(out from, out to);
                if (to != int.MaxValue)
                    ++to;
                FillRandom(array, from, to);
                break;
        }
    }

    public static void KeyboardInput(int[] array)
    {
        int size = array.Length;

        Console.WriteLine("\nЗаполнение одномерного массива целыми числами с клавиатуры.");
        Console.WriteLine($"Нужно ввести {size} целых чисел в диапазоне [{int.MinValue}; {int.MaxValue}]:");
        for (int i = 0; i < size; ++i)
        {
            Console.Write($"Введите ({i + 1} из {size}):\t");
            array[i] = UserInputHandler.Integer.Get();
        }
    }

    public static void FillRandom(int[] array, int from = int.MinValue, int to = int.MaxValue)
    {
        if (from > to)
            throw new Exception($"Error: range is empty [{from}; {to}), from > to");

        int size = array.Length;
        var rand = new Random();

        Console.WriteLine("\nЗаполнение одномерного массива случайными целыми числами.");
        Console.WriteLine($"Будет сгенерировано {size} чисел в диапазоне [{from}; {to - 1}]:");
        for (int i = 0; i < size; ++i)
        {
            array[i] = rand.Next(from, to);

            Console.Write("{0})\t{1, 11}\t", i + 1, array[i]);

            if ((i + 1) % 5 == 0)
                Console.WriteLine();
        }
    }

    public static void ConsoleOutput(int[] array)
    {
        Console.WriteLine("\nВывод всех элементов массива: ");
        for (int i = 0; i < array.Length; ++i)
        {
            Console.Write("{0})\t{1, 11}\t", i + 1, array[i]);

            if ((i + 1) % 5 == 0)
                Console.WriteLine();
        }
    }

    public static void Resize(ref int[] array)
    {
        Console.WriteLine($"\nТекущий размер массива: {array.Length}");
        Console.Write("Введите новый размер массива: ");
        int newSize = UserInputHandler.Integer.GetFromRange(0, 10000);
        Array.Resize(ref array, newSize);
    }

    public static void DeleteFirstNegativeElement(ref int[] array)
    {
        if (array.Length == 0)
        {
            Console.WriteLine("Массив пуст.");
            return;
        }

        int index = Array.FindIndex<int>(array, value => value < 0);

        if (index == -1)
        {
            Console.WriteLine("В массиве нет отрицательных чисел.");
            return;
        }
        
        int value = array[index];

        for (int i = index; i < array.Length - 1; ++i)
            array[i] = array[i + 1];
   
        Array.Resize(ref array, array.Length - 1);
        Console.WriteLine("Удаление завершено.");
        Console.WriteLine($"Первое отрицательное число {value} находилось на позиции {index + 1}.");
    }

    // Money
    public static void Fill(Money[] array)
    {
        Console.WriteLine("\nСпособы заполнения одномерного массива:");
        Console.WriteLine("0) отменить заполнение массива;");
        Console.WriteLine("1) заполнить вручную с клавиатуры;");
        Console.WriteLine("2) сгенерировать случайные значения.");
        Console.Write("Для продолжения введите номер опции: ");

        int menuOptionNumber = UserInputHandler.Integer.GetFromRange(0, 2);

        switch (menuOptionNumber)
        {
            case 0:
                return;
            case 1:
                KeyboardInput(array);
                break;
            case 2:
                int from, to;
                UserInputHandler.Integer.GetRange(out from, out to);
                if (to != int.MaxValue)
                    ++to;
                FillRandom(array, from, to);
                break;
        }
    }

    public static void KeyboardInput(Money[] array)
    {
        int size = array.Length;

        Console.WriteLine("\nЗаполнение одномерного массива Money копейками с клавиатуры.");
        Console.WriteLine($"Нужно ввести {size} целых чисел (количество копеек) в диапазоне [{int.MinValue}; {int.MaxValue}]:");
        for (int i = 0; i < size; ++i)
        {
            Console.Write($"Введите ({i + 1} из {size}):\t");
            array[i] = new Money(UserInputHandler.Integer.Get());
        }
    }

    public static void FillRandom(Money[] array, int from = int.MinValue, int to = int.MaxValue)
    {
        if (from > to)
            throw new Exception($"Error: range is empty [{from}; {to}), from > to");

        int size = array.Length;
        var rand = new Random();

        Console.WriteLine("\nЗаполнение одномерного массива Money случайными целыми числами (количество копеек).");
        Console.WriteLine($"Будет сгенерировано {size} чисел в диапазоне [{from}; {to - 1}]:");
        for (int i = 0; i < size; ++i)
        {
            array[i] = new Money(rand.Next(from, to));

            Console.WriteLine("{0})\t{1, 11} рублей\t{2, 11} копеек", i + 1, array[i].Rubles, array[i].Kopeks);
        }
    }

    public static void ConsoleOutput(Money[] array)
    {
        Console.WriteLine("\nВывод всех элементов массива: ");
        for (int i = 0; i < array.Length; ++i)
        {
            Console.WriteLine("{0})\t{1, 11} рублей\t{2, 11} копеек", i + 1, array[i].Rubles, array[i].Kopeks);
        }
    }
}

class TwoDimensional
{
    // integer
    public static void Fill(int[,] array)
    {
        Console.WriteLine("\nСпособы заполнения двумерного массива:");
        Console.WriteLine("0) отменить заполнение массива;");
        Console.WriteLine("1) заполнить вручную с клавиатуры;");
        Console.WriteLine("2) сгенерировать случайные значения.");
        Console.Write("Для продолжения введите номер опции: ");

        int menuOptionNumber = UserInputHandler.Integer.GetFromRange(0, 2);

        switch (menuOptionNumber)
        {
            case 0:
                return;
            case 1:
                KeyboardInput(array);
                break;
            case 2:
                int from, to;
                UserInputHandler.Integer.GetRange(out from, out to);
                if (to != int.MaxValue)
                    ++to;
                FillRandom(array, from, to);
                break;
        }
    }

    public static void KeyboardInput(int[,] array)
    {
        int rows = array.GetUpperBound(0) + 1;
        int columns = (rows != 0) ? array.Length / rows : 0;
        int size = rows * columns;

        Console.WriteLine("\nЗаполнение двумерного массива целыми числами с клавиатуры.");
        Console.WriteLine($"Двумерный массив состоит из {rows} строк и {columns} столбцов.");
        Console.WriteLine($"Всего нужно ввести {size} целых чисел в диапазоне [{int.MinValue}; {int.MaxValue}]:");

        int counter = 1;
        for (int i = 0; i < rows; ++i)
        {
            for (int j = 0; j < columns; ++j)
            {
                Console.Write($"Введите ({counter} из {size}):\t");
                array[i, j] = UserInputHandler.Integer.Get();
                ++counter;
            }
        }
    }

    public static void FillRandom(int[,] array, int from = int.MinValue, int to = int.MaxValue)
    {
        if (from > to)
            throw new Exception($"Error: range is empty [{from}; {to}), from > to");

        int rows = array.GetUpperBound(0) + 1;
        int columns = (rows != 0) ? array.Length / rows : 0;
        int size = rows * columns;
        var rand = new Random();

        Console.WriteLine("\nЗаполнение двумерного массива случайными целыми числами.");
        Console.WriteLine($"Двумерный массив состоит из {rows} строк и {columns} столбцов.");
        Console.WriteLine($"Будет сгенерировано {size} чисел в диапазоне [{from}; {to - 1}]:");

        for (int i = 0; i < rows; ++i)
        {
            for (int j = 0; j < columns; ++j)
            {
                array[i, j] = rand.Next(from, to);
                Console.Write("{0}x{1})\t{2, 11}\t", i + 1, j + 1, array[i, j]);
            }

            Console.WriteLine();
        }
    }

    public static void ConsoleOutput(int[,] array)
    {
        int rows = array.GetUpperBound(0) + 1;
        int columns = (rows != 0) ? array.Length / rows : 0;

        Console.WriteLine("\nВывод всех элементов массива: ");

        for (int i = 0; i < rows; ++i)
        {
            for (int j = 0; j < columns; ++j)
            {
                Console.Write("{0}x{1})\t{2, 11}\t", i + 1, j + 1, array[i, j]);
            }

            Console.WriteLine();
        }
    }

    public static void AddNewColumn(ref int[,] array, int number)
    {
        int rows = array.GetUpperBound(0) + 1;
        int columns = (rows != 0) ? array.Length / rows : 0;

        int[,] newArray = new int[rows, columns + 1];

        int shift = 0;
        for (int j = 0; j < columns; ++j)
        {
            if (shift == 0 && j == number)
                shift = 1;

            for (int i = 0; i < rows; ++i)
                newArray[i, j + shift] = array[i, j];
        }

        array = newArray;

        Console.WriteLine($"Добавление столбца на позицию {number} завершено.");
    }

    public static void Resize(ref int[,] array)
    {
        int rows = array.GetUpperBound(0) + 1;
        int columns = (rows != 0) ? array.Length / rows : 0;
        int size = rows * columns;

        Console.WriteLine($"\nТекущий размер массива: {size}");
        Console.WriteLine($"Массив состоит из {rows} строк и {columns} столбцов.");

        Console.Write("Введите новое количество строк: ");
        int newRows = UserInputHandler.Integer.GetFromRange(0, 10000);
        Console.Write("Введите новое количество столбцов: ");
        int newColumns = UserInputHandler.Integer.GetFromRange(0, 10000);

        int[,] newArray = new int[newRows, newColumns];

        if (newRows < rows)
            rows = newRows;
        if (newColumns < columns)
            columns = newColumns;

        for (int i = 0; i < rows; ++i)
        {
            for (int j = 0; j < columns; ++j)
                newArray[i, j] = array[i, j];
        }

        array = newArray;
    }

    // double
    public static void Fill(double[,] array, string textFilePath = "default.txt")
    {
        Console.WriteLine("\nСпособы заполнения двумерного массива:");
        Console.WriteLine("0) отменить заполнение массива;");
        Console.WriteLine("1) заполнить вручную с клавиатуры;");
        Console.WriteLine("2) сгенерировать случайные значения;");
        Console.WriteLine("3) считать значения из текстового файла.");
        Console.Write("Для продолжения введите номер опции: ");

        int menuOptionNumber = UserInputHandler.Integer.GetFromRange(0, 3);

        switch (menuOptionNumber)
        {
            case 0:
                return;
            case 1:
                KeyboardInput(array);
                break;
            case 2:
                double from, to;
                UserInputHandler.Number.GetRange(out from, out to);
                FillRandom(array, from, to);
                break;
            case 3:
                TextFileInput(array, textFilePath);
                break;
        }
    }

    public static void TextFileInput(double[,] array, string textFilePath = "default.txt")
    {
        int rows = array.GetUpperBound(0) + 1;
        int columns = (rows != 0) ? array.Length / rows : 0;
        int size = rows * columns;

        using (StreamReader sr = new(textFilePath, System.Text.Encoding.Default))
        {
            for (int i = 0; i < rows; ++i)
            {
                if (sr.Peek() < 0)
                    return;

                string numbers = sr.ReadLine();

                int j = 0;
                foreach (var number in numbers.Split())
                {
                    if (j >= columns)
                        break;
                    
                    double.TryParse(number, out array[i, j]);
                    j++;
                }
            }
        }
    }

    public static void KeyboardInput(double[,] array)
    {
        int rows = array.GetUpperBound(0) + 1;
        int columns = (rows != 0) ? array.Length / rows : 0;
        int size = rows * columns;

        Console.WriteLine("\nЗаполнение двумерного массива числами с клавиатуры.");
        Console.WriteLine($"Двумерный массив состоит из {rows} строк и {columns} столбцов.");
        Console.WriteLine($"Всего нужно ввести {size} чисел в диапазоне [{double.MinValue}; {double.MaxValue}]:");

        int counter = 1;
        for (int i = 0; i < rows; ++i)
        {
            for (int j = 0; j < columns; ++j)
            {
                Console.Write($"Введите ({counter} из {size}):\t");
                array[i, j] = UserInputHandler.Number.Get();
                ++counter;
            }
        }
    }

    public static void FillRandom(double[,] array,
                                  double from = double.MinValue,
                                  double to   = double.MaxValue)
    {
        if (from > to)
            throw new Exception($"Error: range is empty [{from}; {to}), from > to");

        int rows    = array.GetUpperBound(0) + 1;
        int columns = (rows != 0) ? array.Length / rows : 0;
        int size = rows * columns;
        var rand = new Random();

        Console.WriteLine("\nЗаполнение двумерного массива случайными числами.");
        Console.WriteLine($"Двумерный массив состоит из {rows} строк и {columns} столбцов.");
        Console.WriteLine($"Будет сгенерировано {size} чисел в диапазоне [{from}; {to}]:");

        for (int i = 0; i < rows; ++i)
        {
            for (int j = 0; j < columns; ++j)
            {
                array[i, j] = rand.NextDouble() * (to - from) + from;
                Console.Write("{0}x{1})\t{2, 20}\t", i + 1, j + 1, array[i, j]);
            }

            Console.WriteLine();
        }
    }

    public static void ConsoleOutput(double[,] array)
    {
        int rows = array.GetUpperBound(0) + 1;
        int columns = (rows != 0) ? array.Length / rows : 0;

        Console.WriteLine("\nВывод всех элементов массива: ");

        for (int i = 0; i < rows; ++i)
        {
            for (int j = 0; j < columns; ++j)
            {
                Console.Write("{0}x{1})\t{2, 20}\t", i + 1, j + 1, array[i, j]);
            }

            Console.WriteLine();
        }
    }

    public static void Resize(ref double[,] array)
    {
        int rows = array.GetUpperBound(0) + 1;
        int columns = (rows != 0) ? array.Length / rows : 0;
        int size = rows * columns;

        Console.WriteLine($"\nТекущий размер массива: {size}");
        Console.WriteLine($"Массив состоит из {rows} строк и {columns} столбцов.");

        Console.Write("Введите новое количество строк: ");
        int newRows = UserInputHandler.Integer.GetFromRange(0, 10000);
        Console.Write("Введите новое количество столбцов: ");
        int newColumns = UserInputHandler.Integer.GetFromRange(0, 10000);

        double[,] newArray = new double[newRows, newColumns];

        if (newRows < rows)
            rows = newRows;
        if (newColumns < columns)
            columns = newColumns;

        for (int i = 0; i < rows; ++i)
        {
            for (int j = 0; j < columns; ++j)
                newArray[i, j] = array[i, j];
        }

        array = newArray;
    }

    public static void DeleteFirstRowThatHasLeastOneZero(ref double[,] array)
    {
        int rows = array.GetUpperBound(0) + 1;

        if (rows == 0)
        {
            Console.WriteLine("\nМассив не содержит строк.");
            return;
        }

        int columns = array.Length / rows;

        double eps = 1e-10;
        bool rowIsFound = false;
        int indexFirstRowThatHasLeastOneZero = 0;
        for (int i = 0; i < rows; ++i)
        {
            for (int j = 0; j < columns; ++j)
            {
                if (Math.Abs(array[i, j]) < eps)
                {
                    rowIsFound = true;
                    indexFirstRowThatHasLeastOneZero = i;
                    break;
                }
            }

            if (rowIsFound)
                break;
        }

        if (rowIsFound)
        {
            int newRows = rows - 1;
            double[,] newArray = new double[newRows, columns];

            for (int i = 0; i < newRows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    if (i < indexFirstRowThatHasLeastOneZero)
                        newArray[i, j] = array[i, j];
                    else
                        newArray[i, j] = array[i + 1, j];
                }
            }

            array = newArray;
            Console.WriteLine("\nПервая строка, в которой был хотя бы один ноль, удалена.");
        }
        else
            Console.WriteLine("\nСтрока, содержащая хотя бы один элемент 0, не найдена.");
    }
}

class Jagged
{
    // integer
    public static void Fill(int[][] array)
    {
        Console.WriteLine("\nСпособы заполнения двумерного массива:");
        Console.WriteLine("0) отменить заполнение массива;");
        Console.WriteLine("1) заполнить вручную с клавиатуры;");
        Console.WriteLine("2) сгенерировать случайные значения.");
        Console.Write("Для продолжения введите номер опции: ");

        int menuOptionNumber = UserInputHandler.Integer.GetFromRange(0, 2);

        switch (menuOptionNumber)
        {
            case 0:
                return;
            case 1:
                KeyboardInput(array);
                break;
            case 2:
                int from, to;
                UserInputHandler.Integer.GetRange(out from, out to);
                if (to != int.MaxValue)
                    ++to;
                FillRandom(array, from, to);
                break;
        }
    }

    public static void KeyboardInput(int[][] array)
    {
        int rows = array.Length;

        Console.WriteLine("\nЗаполнение зубчатого массива целыми числами с клавиатуры.");
        Console.WriteLine($"Массив состоит из {rows} строк.");

        for (int i = 0; i < rows; ++i)
        {
            Console.Write($"Введите размер {i + 1} строки: ");
            int size = UserInputHandler.Integer.GetFromRange(0, 10000);
            array[i] = new int[size];

            int counter = 1;
            for (int j = 0; j < size; ++j)
            {
                Console.Write($"Введите ({counter} из {size}):\t");
                array[i][j] = UserInputHandler.Integer.Get();
                ++counter;
            }
        }
    }

    public static void FillRandom(int[][] array, int from = int.MinValue, int to = int.MaxValue)
    {
        if (from > to)
            throw new Exception($"Error: range is empty [{from}; {to}), from > to");

        int rows = array.Length;
        var rand = new Random();

        Console.WriteLine("\nЗаполнение зубчатого массива случайными целыми числами.");
        Console.WriteLine($"Массив состоит из {rows} строк.");

        for (int i = 0; i < rows; ++i)
        {
            int size = rand.Next(0, 6);
            Console.WriteLine($"Случайный размер {i + 1} строки: {size}");
            array[i] = new int[size];

            for (int j = 0; j < size; ++j)
            {
                array[i][j] = rand.Next(from, to);
                Console.Write("{0}x{1})\t{2, 11}\t", i + 1, j + 1, array[i][j]);
            }

            Console.WriteLine();
        }
    }

    public static void ConsoleOutput(int[][] array)
    {
        int rows = array.Length;

        Console.WriteLine("\nВывод всех элементов массива: ");

        for (int i = 0; i < rows; ++i)
        {
            int columns = array[i].Length;
            for (int j = 0; j < columns; ++j)
            {
                Console.Write("{0}x{1})\t{2, 11}\t", i + 1, j + 1, array[i][j]);
            }

            Console.WriteLine();
        }
    }

    public static void DeleteShortestRow(ref int[][] array)
    {
        int rows = array.Length;

        if (rows == 0)
        {
            Console.WriteLine("\nМассив не содержит строк.");
            return;
        }

        if (rows == 1)
        {
            Console.WriteLine("\nЕдинственная строка массива удалена.");
            array = new int[0][];
            return;
        }

        Console.WriteLine("\nИдёт поиск самой короткой строки.");
        int newRows = array.Length - 1;
        int[][] newArray = new int[newRows][];

        int shortestRowLength = int.MaxValue;
        int indexOfShortestRow = 0;

        for (int i = 0; i < rows; ++i)
        {
            if (array[i].Length < shortestRowLength)
            {
                shortestRowLength = array[i].Length;
                indexOfShortestRow = i;
            }
        }

        int shift = 0;
        for (int i = 0; i < newRows; ++i)
        {
            if (shift == 0 && i == indexOfShortestRow)
                shift = 1;

            newArray[i] = new int[array[i + shift].Length];
            newArray[i] = array[i + shift];
        }

        array = newArray;

        Console.WriteLine($"Размер самой короткой строки под номером {indexOfShortestRow + 1} равен: {shortestRowLength}");
        Console.WriteLine("Удаление самой короткой строки завершено.");
    }

    public static void Resize(ref int[][] array)
    {
        int rows = array.Length;

        Console.WriteLine($"\nТекущий зубчатый массив состоит из {rows} строк.");

        Console.Write("Введите новое количество строк: ");
        int newRows = UserInputHandler.Integer.GetFromRange(0, 10000);

        int[][] newArray = new int[newRows][];

        if (newRows < rows)
            rows = newRows;

        for (int i = 0; i < rows; ++i)
        {
            newArray[i] = new int[array[i].Length];
            newArray[i] = array[i];
        }

        array = newArray;
    }
}