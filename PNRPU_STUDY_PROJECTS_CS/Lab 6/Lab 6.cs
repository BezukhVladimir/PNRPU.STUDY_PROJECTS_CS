namespace Lab6
{
    class Lab
    {
        public static void SolveFirstTask()
        {
            double[,] array = new double[0, 0];

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
                Console.WriteLine("4) удалить из массива первую строку, в которой есть хотя бы один ноль.");
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
                        ArrayHandler.TwoDimensional.DeleteFirstRowThatHasLeastOneZero(ref array);
                        break;
                }
            }
        }

        public static void SolveSecondTask()
        {
            string? data = "";
            string pattern = @"(^|(?<=[\s,;:.!?])+)[A-Za-z]+($|(?=[\s,;:.!?]+))";
          
            while (true)
            {
                Console.WriteLine($"\nРабота со строкой: {data}");
                Console.WriteLine("0) выход в меню лабораторной работы;");
                Console.WriteLine("1) ввести новую строку с клавиатуры;");
                Console.WriteLine("2) установить строку-пример;");
                Console.WriteLine($"3) оставить в строке подстроки, соответствующие паттерну {pattern};");
                Console.WriteLine($"4) инвертировать все чётные подстроки, соответствующие паттерну {pattern}.");
                Console.Write("Для продолжения введите номер опции: ");

                int menuOptionNumber = UserInputHandler.Integer.GetFromRange(0, 4);

                switch (menuOptionNumber)
                {
                    case 0:
                        return;
                    case 1:
                        data = UserInputHandler.String.Get();
                        break;
                    case 2:
                        data = "startword first    second,third;fourth:not#word not1word: fifth,, ; sixth; preendword.endword\nstartword first    second,third;fourth:not#word not1word: fifth,, ; sixth; preendword!endword\nstartword first    second,third;fourth:not#word not1word: fifth,, ; sixth; preendword?endword";
                        break;
                    case 3:
                        data = StringHandler.RegexHandler.GetMatches(data, pattern);
                        break;
                    case 4:
                        data = StringHandler.SpecificTaskHandler.ReverseEverySecondMatch(data, pattern);
                        break;
                }
            }
        }

        public static void ShowTaskMenu()
        {
            while (true)
            {
                Console.WriteLine("\nОпции лабораторной работы №6:");
                Console.WriteLine("0) завершение работы программы;");
                Console.WriteLine("1) первое задание;");
                Console.WriteLine("2) второе задание.");
                Console.Write("Для продолжения введите номер опции: ");

                int menuOptionNumber = UserInputHandler.Integer.GetFromRange(0, 2);

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
                }
            }
        }
    }
}