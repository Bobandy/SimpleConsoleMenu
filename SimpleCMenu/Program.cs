using System;

using SimpleCMenu.Menu;

namespace SimpleCMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            string headerText = "  __  __                     _____           _                 " +
                Environment.NewLine + " |  \\/  |                   / ____|         | |                " +
                Environment.NewLine + " | \\  / | ___ _ __  _   _  | (___  _   _ ___| |_ ___ _ __ ___" +
                Environment.NewLine + " | |\\/| |/ _ \\ '_ \\| | | |  \\___ \\| | | / __| __/ _ \\ '_ ` _ \\" +
                Environment.NewLine + " | |  | |  __/ | | | |_| |  ____) | |_| \\__ \\ ||  __/ | | | | |" +
                Environment.NewLine + " |_|  |_|\\___|_| |_|\\__,_| |_____/ \\__, |___/\\__\\___|_| |_| |_|" +
                Environment.NewLine + "                                    __/ |    " +
                Environment.NewLine + "                                   |___/             ";


            Console.Clear();

            // Setup the menu
            ConsoleMenu mainMenu = new ConsoleMenu();

            ConsoleMenu subMenu1 = new ConsoleMenu("==>");
            subMenu1.SubTitle = "---------------- Secret Menu -----------------";
            subMenu1.addMenuItem(0, "backToMain", subMenu1.hideMenu);
            subMenu1.ParentMenu = mainMenu;

            mainMenu.Header = headerText;
            subMenu1.Header = mainMenu.Header;

            mainMenu.SubTitle = "-------------------- Menu ----------------------";
            mainMenu.addMenuItem(0, "Hello World!", HelloWorld);
            mainMenu.addMenuItem(1, "Secret Menu", subMenu1.showMenu);
            mainMenu.addMenuItem(2, "Exit", Exit);
            // Display the menu
            mainMenu.showMenu();

        }


        public static void Exit()
        {
            Environment.Exit(0);
        }

        public static void HelloWorld()
        {
            Console.WriteLine("Hello World!");
            Console.ReadKey(true);
        }
    }
}
