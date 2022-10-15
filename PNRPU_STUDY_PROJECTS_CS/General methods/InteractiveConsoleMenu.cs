namespace InteractiveConsoleMenu;

public abstract class MenuItem
{
    public string Name { get; set; }

    public MenuItem(string name)
    {
        Name  = name;
    }
}

public class MenuCategory : MenuItem
{
    public string     Title { get; set; }
    public MenuItem[] Items { get; set; }

    public MenuCategory(string name, string title, MenuItem[] items) : base(name)
    {
        Title = title;
        Items = items;
    }
}

public class MenuAction : MenuItem
{
    public Action Action { get; set; }

    public MenuAction(string name, Action action) : base(name)
    {
        Action = action;
    }
}

public class MenuBack : MenuItem
{
    public MenuBack(string name = "Вернуться к предыдущему меню") : base(name) { }
}

public class Menu
{
    public MenuCategory currentCategory;
    public int downMenuIndex;

    public Menu(MenuCategory root)
    {
        currentCategory = root;
    }

    public void Run(int leftCursorPosition = 0, int topCursorPosition = 0)
    {
        Stack<MenuCategory> wayBack = new Stack<MenuCategory>();
        int currentCategoryIndex = 0;
        while (true)
        {
            DrawMenu(leftCursorPosition, topCursorPosition, currentCategoryIndex);
            DrawHelp();
            downMenuIndex = Console.GetCursorPosition().Top;

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                    if (currentCategoryIndex > 0)
                        currentCategoryIndex--;
                    else
                        currentCategoryIndex = currentCategory.Items.Length - 1;
                    break;
                case ConsoleKey.DownArrow:
                    if (currentCategoryIndex < currentCategory.Items.Length - 1)
                        currentCategoryIndex++;
                    else
                        currentCategoryIndex = 0;
                    break;
                case ConsoleKey.Enter:
                case ConsoleKey.Spacebar:
                    switch (currentCategory.Items[currentCategoryIndex])
                    {
                        case MenuCategory category:
                            wayBack.Push(currentCategory);
                            currentCategoryIndex = 0;
                            currentCategory = category;
                            Console.Clear();
                            break;
                        case MenuAction action:
                            action.Action();
                            break;
                        case MenuBack:
                            Console.Clear();
                            if (wayBack.Count == 0)
                                return;
                            MenuCategory parent = wayBack.Pop();
                            currentCategoryIndex = Array.IndexOf(parent.Items, currentCategory);
                            currentCategory = parent;
                            break;
                        default:
                            throw new InvalidCastException("Неизвестный тип пункта меню.");
                    }
                    break;
            }
        }
    }

    private void DrawMenu(int left, int top, int currentIndex)
    {
        Console.SetCursorPosition(left, top);
        Console.WriteLine(currentCategory.Title);
        Console.WriteLine();

        for (int i = 0; i < currentCategory.Items.Length; ++i)
        {
            if (i == currentIndex)
            {
                Console.BackgroundColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Black;
            }

            Console.WriteLine(currentCategory.Items[i].Name);
            Console.ResetColor();
        }
    }

    private void DrawHelp()
    {
        Console.WriteLine("\nДля навигации по меню используйте клавиши управления курсором «вверх» и «вниз».");
        Console.WriteLine("Для активации выбранной опции нажмите клавишу «ввод» или «пробел».");
        Console.WriteLine("Developed by Bezukh");
    }
}