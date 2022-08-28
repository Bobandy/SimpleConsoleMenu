namespace SimpleConsoleMenu;

public class Menu
{
    private readonly List<MenuItem> _menuItemList;

    private int _cursor;
    private bool _isExit;

    public Menu(string cursorText = "->")
    {
        _menuItemList = new();
        _cursor = 0;

        CursorText = cursorText;
        CursorColor = ConsoleColor.Yellow;
        HeaderColor = ConsoleColor.Blue;
        ForeColor = ConsoleColor.White;
        MenuItemColor = ConsoleColor.White;
        SubTitleColor = ConsoleColor.White;
    }

    public Menu? ParentMenu { get; set; }

    public string Header { get; set; } = string.Empty;
    public string SubTitle { get; set; } = string.Empty;
    public string CursorText { get; set; }
    public ConsoleColor CursorColor { get; set; }
    public ConsoleColor HeaderColor { get; set; }
    public ConsoleColor ForeColor { get; set; }
    public ConsoleColor MenuItemColor { get; set; }
    public ConsoleColor SubTitleColor { get; set; }

    /// <summary>
    /// Show menu in console and handle use input, will not return until user use Escape key
    /// </summary>
    public void ShowMenu()
    {
        Console.CursorVisible = false;
        ReprintWithHeader();
        _isExit = false;
        // TODO: this is bad, may generate loop inside many loops in menu tree
        while (!_isExit)
        {
            UpdateMenu();
        }
    }

    /// <summary>
    /// Add menu item
    /// </summary>
    /// <param name="text">print text in menu</param>
    /// <param name="action">behavior that will be invoked on execute menu item</param>
    /// <returns></returns>
    public bool AddMenuItem(string text, Action action)
    {
        _menuItemList.Add(new(_menuItemList.Count, text, action));
        return true;
    }

    /// <summary>
    /// Will open parent menu if it exist
    /// </summary>
    /// <exception cref="InvalidOperationException">Throw if parent menu not registered</exception>
    public void Back()
    {
        if (ParentMenu is null) throw new InvalidOperationException("You not register parent menu");

        HideMenu();
        ParentMenu?.ShowMenu();
    }

    /// <summary>
    /// Exit from menu loop
    /// </summary>
    public void Close()
    {
        // TODO: fix this: on close open parent menu
        ParentMenu?.Close();
        HideMenu();
    }

    private void HideMenu() => _isExit = true;

    private void DrawHeader()
    {
        Console.ForegroundColor = HeaderColor;
        Console.WriteLine(Header);
        Console.ForegroundColor = ForeColor;
    }

    private void DrawWithHeader()
    {
        DrawHeader();
        Draw();
    }

    private void Draw()
    {
        Console.WriteLine(SubTitle);

        for (var i = 0; i < _menuItemList.Count; i++)
        {
            if (i == _cursor)
            {
                Console.ForegroundColor = CursorColor;
                Console.Write(CursorText + " ");
                Console.WriteLine(_menuItemList[i].Text);
                Console.ForegroundColor = ForeColor;
                continue;
            }

            Console.Write(new string(' ', CursorText.Length + 1));
            Console.WriteLine(_menuItemList[i].Text);
        }
    }

    private static void Clear() => Console.Clear();

    private void ReprintWithoutHeader()
    {
        Clear();
        DrawHeader();
    }

    private void ReprintWithHeader()
    {
        Clear();
        DrawWithHeader();
    }

    private void UpdateMenu()
    {
        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.UpArrow:
                if (_cursor > 0)
                {
                    _cursor--;
                    ReprintWithHeader();
                }
                break;
            case ConsoleKey.DownArrow:
                if (_cursor < _menuItemList.Count - 1)
                {
                    _cursor++;
                    ReprintWithHeader();
                }
                break;
            case ConsoleKey.Escape:
                Back();
                break;
            case ConsoleKey.Enter:
                ExecuteMenuItem();
                break;
        }
    }

    private void ExecuteMenuItem()
    {
        ReprintWithoutHeader();
        Console.CursorVisible = true;
        _menuItemList[_cursor].Action();
        Console.CursorVisible = false;
        ReprintWithHeader();
    }

    private class MenuItem
    {
        public int Id { get; }
        public string Text { get; }
        public Action Action { get; }

        public MenuItem(int id, string text, Action action)
        {
            Id = id;
            Text = text;
            Action = action;
        }
    }
}