using InteractiveConsoleMenu;

namespace Lab6
{
    public class Lab
    {
        public static Menu menu = new(
            new MenuCategory("Главное меню",
                             "Опции лабораторной работы №6", new MenuItem[]{
                new MenuBack("Завершить работу программы"),
                new MenuCategory("Выполнить первое задание",
                                $"Работа с двумерным массивом [{SolveFirstTask.Rows} x {SolveFirstTask.Columns}] (текущий размер — {SolveFirstTask.Size}):", new MenuItem[]{
                    new MenuBack("Вернуться к опциям лабораторной работы №6"),
                    new MenuAction("Изменить размер массива", SolveFirstTask.FirstAction),
                    new MenuAction("Заполнить массив целиком", SolveFirstTask.SecondAction),
                    new MenuAction("Напечатать массив целиком", SolveFirstTask.ThirdAction),
                    new MenuAction("Удалить из массива первую строку, в которой есть хотя бы один ноль.", SolveFirstTask.FourthAction)}),
                new MenuCategory("Выполнить второе задание",
                                 $"Работа со строкой: {SolveSecondTask.Data}\nПаттерн: {SolveSecondTask.Pattern}", new MenuItem[]{
                    new MenuBack("Вернуться к опциям лабораторной работы №6"),
                    new MenuAction("Ввести новую строку с клавиатуры", SolveSecondTask.FirstAction),
                    new MenuAction("Установить строку-пример", SolveSecondTask.SecondAction),
                    new MenuAction("Оставить в строке подстроки, соответствующие паттерну", SolveSecondTask.ThirdAction),
                    new MenuAction("Инвертировать все чётные подстроки, соответствующие паттерну", SolveSecondTask.FourthAction)}),
        }));
        public static int menuStartIndex = 0;
        public static int downWorkAreaIndex = menuStartIndex;

        public static void ShowTaskMenu()
        {
            menu.Run();
        }

        private class SolveFirstTask
        {
            public static int Rows    { get; private set; }
            public static int Columns { get; private set; }
            public static int Size    { get; private set; }
            public static double[,] s_array = new double[0, 0];
            
            private static void UpdateData()
            {
                Rows    = s_array.GetUpperBound(0) + 1;
                Columns = (Rows != 0) ? s_array.Length / Rows : 0;
                Size    = Rows * Columns;
                menu.currentCategory.Title = $"Работа с двумерным массивом [{SolveFirstTask.Rows} x {SolveFirstTask.Columns}] (текущий размер — {SolveFirstTask.Size}):              ";
            }

            public static void FirstAction()
            {
                if (downWorkAreaIndex != menuStartIndex)
                    ConsoleHandler.Cleaner.ClearRowsInRange(menu.downMenuIndex, downWorkAreaIndex);

                ArrayHandler.TwoDimensional.Resize(ref s_array);
                downWorkAreaIndex = Console.CursorTop;
                ConsoleHandler.Cleaner.ClearRowsInRange(menu.downMenuIndex, downWorkAreaIndex);

                UpdateData();
            }

            public static void SecondAction()
            {
                if (downWorkAreaIndex != menuStartIndex)
                    ConsoleHandler.Cleaner.ClearRowsInRange(menu.downMenuIndex, downWorkAreaIndex);

                ArrayHandler.TwoDimensional.Fill(s_array);
                downWorkAreaIndex = Console.CursorTop;
                ThirdAction();
            }

            public static void ThirdAction()
            {
                if (downWorkAreaIndex != menuStartIndex)
                    ConsoleHandler.Cleaner.ClearRowsInRange(menu.downMenuIndex, downWorkAreaIndex);

                ArrayHandler.TwoDimensional.ConsoleOutput(s_array);
                downWorkAreaIndex = Console.CursorTop;
            }

            public static void FourthAction()
            {
                if (downWorkAreaIndex != menuStartIndex)
                    ConsoleHandler.Cleaner.ClearRowsInRange(menu.downMenuIndex, downWorkAreaIndex);

                ArrayHandler.TwoDimensional.DeleteFirstRowThatHasLeastOneZero(ref s_array);
                downWorkAreaIndex = Console.CursorTop;

                UpdateData();
            }
        }

        class SolveSecondTask
        {
            private static string data = "";
            private static string pattern = @"(^|(?<=[\s,;:.!?])+)[A-Za-z]+($|(?=[\s,;:.!?]+))";

            public static string Data
            {
                get
                {
                    return data;
                }
                private set
                {
                    data = value;
                }
            }
            public static string Pattern
            {
                get
                {
                    return pattern;
                }
                private set
                {
                    pattern = value;
                }
            }

            private static void UpdateMenu()
            {
                menu.currentCategory.Title = $"Работа со строкой: {SolveSecondTask.Data}\nПаттерн: {SolveSecondTask.Pattern}";
                Console.Clear();
            }

            public static void FirstAction()
            {
                string? temp = UserInputHandler.String.Get();

                if (temp is null)
                    return;
                
                Data = temp;
                UpdateMenu();
            }

            public static void SecondAction()
            {
                Data = "startword first    second,third;fourth:not#word not1word: fifth,, ; sixth; preendword.endword\nstartword first    second,third;fourth:not#word not1word: fifth,, ; sixth; preendword!endword\nstartword first    second,third;fourth:not#word not1word: fifth,, ; sixth; preendword?endword";
                UpdateMenu();
            }

            public static void ThirdAction()
            {
                Data = StringHandler.RegexHandler.GetMatches(Data, Pattern);
                UpdateMenu();
            }
           
            public static void FourthAction()
            {
                Data = StringHandler.SpecificTaskHandler.ReverseEverySecondMatch(Data, Pattern);
                UpdateMenu();
            }           
        }
    }
}