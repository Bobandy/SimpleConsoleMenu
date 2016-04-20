using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCMenu.Menu
{
    public class ConsoleMenu
    {
        #region Public var

        public ConsoleMenu ParentMenu { get; set; }

        public string Header { get; set; }
        public string SubTitle { get; set; }
        public string CursorText { get; set; }
        public ConsoleColor CursorColor { get; set; }
        public ConsoleColor HeaderColor { get; set; }
        public ConsoleColor ForeColor { get; set; }
        public ConsoleColor MenuItemColor { get; set; }
        public ConsoleColor SubTitleColor { get; set; }

        #endregion

        #region Private var

        private List<MenuItem> menuItemList;

        private int cursor;
        private bool exit;

        #endregion

        #region Constructor

        public ConsoleMenu(string cursorText = "->")
        {
            menuItemList = new List<MenuItem>();
            cursor = 0;

            this.CursorText = cursorText;
            CursorColor = ConsoleColor.Yellow;
            HeaderColor = ConsoleColor.Blue;
            ForeColor = ConsoleColor.White;
            MenuItemColor = ConsoleColor.White;
            SubTitleColor = ConsoleColor.White;
        }

        #endregion 

        #region Public methods

        public bool addMenuItem(int id, string text, Action action)
        {
            // check if it dosen't already exists
            if (!menuItemList.Any(item => item.ID == id))
            {
                menuItemList.Add(new MenuItem(id, text, action));
                return true;
            }
            return false;
        }

        public bool removeMenuItem(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Public Virtual methods

        public virtual void drawHeader()
        {
            Console.ForegroundColor = HeaderColor;
            Console.WriteLine(Header);
            Console.ForegroundColor = ForeColor;
        }

        public virtual void drawWithHeader()
        {
            drawHeader();
            draw();
        }

        public virtual void draw()
        {
            Console.WriteLine(SubTitle);

            for (int i = 0; i < menuItemList.Count; i++)
            {
                if (i == cursor)
                {
                    Console.ForegroundColor = CursorColor;
                    Console.Write(CursorText + " ");
                    Console.WriteLine(menuItemList[i].Text);
                    Console.ForegroundColor = ForeColor;
                }
                else
                {
                    Console.Write(new string(' ', (CursorText.Length + 1)));
                    Console.WriteLine(menuItemList[i].Text);
                }
            }
        }

        public virtual void clear()
        {
            Console.Clear();
        }

        public virtual void clearWithoutHeader()
        {
            Console.Clear();
            drawHeader();
        }

        public virtual void showMenu()
        {
            Console.CursorVisible = false;
            Console.Clear();
            drawWithHeader();
            exit = false;
            while (!exit)
            {
                updateMenu();
            }
        }

        public virtual void hideMenu()
        {
            exit = true;
        }

        public virtual void updateMenu()
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                    {
                        if (cursor > 0)
                        {
                            cursor--;
                            Console.Clear();
                            drawWithHeader();
                        }
                    }
                    break;
                case ConsoleKey.DownArrow:
                    {
                        if (cursor < (menuItemList.Count - 1))
                        {
                            cursor++;
                            Console.Clear();
                            drawWithHeader();
                        }
                    }
                    break;
                case ConsoleKey.Escape:
                    {
                        if (ParentMenu != null)
                        {

                            hideMenu();
                        }
                    }
                    break;
                case ConsoleKey.Enter:
                    {
                        Console.Clear();
                        drawHeader();
                        Console.CursorVisible = true;
                        menuItemList[cursor].Action();
                        Console.CursorVisible = false;
                        Console.Clear();
                        drawWithHeader();
                    }
                    break;
                default:
                    {
                        // Unsuported key. Do nothing....
                    }
                    break;
            }
        }

        #endregion
    }
}
