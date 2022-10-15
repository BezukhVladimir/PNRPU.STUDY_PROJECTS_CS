namespace Lab5
{
    class Lab
    {
        public static void SolveFirstTask()
        {
            int[] array = new int[0];

            while (true)
            {
                Console.WriteLine($"\nРабота с одномерным массивом (текущий размер — {array.Length}):");
                Console.WriteLine("0) выход в меню лабораторной работы;");
                Console.WriteLine("1) изменить размер массива;");
                Console.WriteLine("2) заполнить массив целиком;");
                Console.WriteLine("3) напечатать массив целиком;");
                Console.WriteLine("4) удалить первый отрицательный элемент массива.");
                Console.Write("Для продолжения введите номер опции: ");

                int menuOptionNumber = UserInputHandler.Integer.GetFromRange(0, 4);

                switch (menuOptionNumber)
                {
                    case 0:
                        return;
                    case 1:
                        ArrayHandler.OneDimensional.Resize(ref array);
                        break;
                    case 2:
                        ArrayHandler.OneDimensional.Fill(array);
                        break;
                    case 3:
                        ArrayHandler.OneDimensional.ConsoleOutput(array);
                        break;
                    case 4:
                        ArrayHandler.OneDimensional.DeleteFirstNegativeElement(ref array);
                        break;
                }
            }
        }

        public static void SolveSecondTask()
        {
            int[,] array = new int[0, 0];

            while (true)
            {
                int rows = array.GetUpperBound(0) + 1;
                int columns = (rows != 0) ? array.Length / rows : 0;
                int size = rows * columns;

                Console.WriteLine($"\nРабота с двумерным массивом [{rows} x {columns}] (текущий размер — {size}):");
                Console.WriteLine("0) выход в меню лабораторной работы;");
                Console.WriteLine("1) изменить размер массива;");
                Console.WriteLine("2) заполнить массив целиком;");
                Console.WriteLine("3) напечатать массив целиком;");
                Console.WriteLine("4) добавить столбец с заданным номером.");
                Console.Write("Для продолжения введите номер опции: ");

                int menuOptionNumber = UserInputHandler.Integer.GetFromRange(0, 4);

                switch (menuOptionNumber)
                {
                    case 0:
                        return;
                    case 1:
                        ArrayHandler.TwoDimensional.Resize(ref array);
                        break;
                    case 2:
                        ArrayHandler.TwoDimensional.Fill(array);
                        break;
                    case 3:
                        ArrayHandler.TwoDimensional.ConsoleOutput(array);
                        break;
                    case 4:
                        Console.Write($"\nВведите позицию от 1 до {columns + 1}, куда вставить новый столбец: ");
                        ArrayHandler.TwoDimensional.AddNewColumn(ref array,
                            UserInputHandler.Integer.GetFromRange(1, columns + 1) - 1);
                        break;
                }
            }
        }

        public static void SolveThirdTask()
        {
            int[][] array = new int[0][];

            while (true)
            {
                int rows = array.Length;

                Console.WriteLine($"\nРабота с рваным массивом (количество строк — {rows}):");
                Console.WriteLine("0) выход в меню лабораторной работы;");
                Console.WriteLine("1) изменить количество строк массива;");
                Console.WriteLine("2) заполнить массив целиком;");
                Console.WriteLine("3) напечатать массив целиком;");
                Console.WriteLine("4) удалить самую короткую строку.");
                Console.Write("Для продолжения введите номер опции: ");

                int menuOptionNumber = UserInputHandler.Integer.GetFromRange(0, 4);

                switch (menuOptionNumber)
                {
                    case 0:
                        return;
                    case 1:
                        ArrayHandler.Jagged.Resize(ref array);
                        break;
                    case 2:
                        ArrayHandler.Jagged.Fill(array);
                        break;
                    case 3:
                        ArrayHandler.Jagged.ConsoleOutput(array);
                        break;
                    case 4:
                        ArrayHandler.Jagged.DeleteShortestRow(ref array);
                        break;
                }
            }
        }

        public static void ShowTaskMenu()
        {
            while (true)
            {
                Console.WriteLine("\nОпции лабораторной работы №5:");
                Console.WriteLine("0) завершение работы программы;");
                Console.WriteLine("1) работа с одномерными массивом;");
                Console.WriteLine("2) работа с двумерными массивом;");
                Console.WriteLine("3) работа с зубчатым массивом.");
                Console.Write("Для продолжения введите номер опции: ");

                int menuOptionNumber = UserInputHandler.Integer.GetFromRange(0, 3);

                switch (menuOptionNumber)
                {
                    case 0:
                        return;
                    case 1:
                        SolveFirstTask();
                        break;
                    case 2:
                        SolveSecondTask();
                        break;
                    case 3:
                        SolveThirdTask();
                        break;
                }
            }
        }
    }
}