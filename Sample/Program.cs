using SimpleConsoleMenu;

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
Menu mainMenu = new ();

Menu subMenu1 = new ("==>");
subMenu1.SubTitle = "---------------- Secret Menu -----------------";
subMenu1.AddMenuItem("backToMain", subMenu1.Back);
subMenu1.ParentMenu = mainMenu;

mainMenu.Header = headerText;
subMenu1.Header = mainMenu.Header;

mainMenu.SubTitle = "-------------------- Menu ----------------------";
mainMenu.AddMenuItem("Hello World!", HelloWorld);
mainMenu.AddMenuItem("Secret Menu", subMenu1.ShowMenu);
mainMenu.AddMenuItem("Exit", Exit);
// Display the menu
mainMenu.ShowMenu();


static void Exit()
{
    Environment.Exit(0);
}

static void HelloWorld()
{
    Console.WriteLine("Hello World!");
    Console.ReadKey(true);
}