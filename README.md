# SimpleConsoleMenu
a simple and customisable c# console menu system 

![alt tag](https://raw.githubusercontent.com/Bobandy/SimpleConsoleMenu/master/SC1.PNG)
![alt tag](https://raw.githubusercontent.com/Bobandy/SimpleConsoleMenu/master/SC2.PNG)

```c#
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
```
