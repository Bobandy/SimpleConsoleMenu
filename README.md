# SimpleConsoleMenu
a simple and customisable c# console menu system 

![alt tag](https://raw.githubusercontent.com/Bobandy/SimpleConsoleMenu/master/SC1.PNG)
![alt tag](https://raw.githubusercontent.com/Bobandy/SimpleConsoleMenu/master/SC2.PNG)

```c#
// Setup the menu
ConsoleMenu mainMenu = new ConsoleMenu();

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
```
