using InteractiveConsoleMenu;
using System;

namespace Lab2_DiscreteMathematics
{
    public class Lab
    {
        private static DiscreteMathematics.Matrix relationsMatrix = new();
        private static Menu menu = new(
                new MenuCategory(
                    "Главное меню",
                    "Опции лабораторной работы №2", new MenuItem[]{
                    new MenuBack("Завершить работу программы"),
                    new MenuAction("Изменить размер матрицы", FirstAction),
                    new MenuAction("Заполнить матрицу целиком", SecondAction),
                    new MenuAction("Напечатать матрицу целиком", ThirdAction),
                    new MenuAction("Напечатать свойства матрицы", FourthAction),
                    new MenuAction("Напечатать свойства отношений", FifthAction)}));
        private static int menuStartIndex = 0;
        private static int downWorkAreaIndex = menuStartIndex;
        private static string textFilePath = "D:\\C#\\PNRPU_STUDY_PROJECTS_CS\\PNRPU_STUDY_PROJECTS_CS\\Lab 2 (discrete mathematics)\\relationsMatrix.txt";

        public static void ShowTaskMenu()
        {
            menu.Run();
        }

        public static void FirstAction()
        {
            if (downWorkAreaIndex != menuStartIndex)
                ConsoleHandler.Cleaner.ClearRowsInRange(menu.downMenuIndex, downWorkAreaIndex);

            relationsMatrix.Resize();
            downWorkAreaIndex = Console.CursorTop;
            ConsoleHandler.Cleaner.ClearRowsInRange(menu.downMenuIndex, downWorkAreaIndex);
        }

        public static void SecondAction()
        {
            if (downWorkAreaIndex != menuStartIndex)
                ConsoleHandler.Cleaner.ClearRowsInRange(menu.downMenuIndex, downWorkAreaIndex);

            relationsMatrix.Fill(textFilePath);
            downWorkAreaIndex = Console.CursorTop;
            ThirdAction();
        }

        public static void ThirdAction()
        {
            if (downWorkAreaIndex != menuStartIndex)
                ConsoleHandler.Cleaner.ClearRowsInRange(menu.downMenuIndex, downWorkAreaIndex);

            relationsMatrix.Show();
            downWorkAreaIndex = Console.CursorTop;
        }

        public static void FourthAction()
        {
            if (downWorkAreaIndex != menuStartIndex)
                ConsoleHandler.Cleaner.ClearRowsInRange(menu.downMenuIndex, downWorkAreaIndex);

            relationsMatrix.ShowMatrixProperties();
            downWorkAreaIndex = Console.CursorTop;
        }

        public static void FifthAction()
        {
            if (downWorkAreaIndex != menuStartIndex)
                ConsoleHandler.Cleaner.ClearRowsInRange(menu.downMenuIndex, downWorkAreaIndex);

            relationsMatrix.ShowRelationshipsProperties();
            downWorkAreaIndex = Console.CursorTop;
        }
    }
}