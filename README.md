
# Visual Basic Console Menu
![license](https://img.shields.io/hexpm/l/plug.svg)

This library provides a way to quickly create the menu for your VB.net console app.

##  Overview

### Classes

#### AbstractMenu
This is the abstract class you need to extend in your menus.
It's constructor takes in a title which is displayed at the top of the menu. This should be called from your implementations constructor. Like so:
```vb
public Sub New()
    MyBase.New("Menu Title")
End Sub
```
##### Methods
- `Init()` this needs overridding in your implementations and is where you add the items to the menu.
- `Display()` this starts this menu. This only needs to be called on the root menu in your system, as all sub-menus are handled by this library.
- `AddMenuItem(new MenuItem(id, description, subMenu or action))` this adds an item to the menu. 
- `AddHiddenMenuItem(new MenuItem(id, description, subMenu or action))` this is a helper method that adds a menu item, which is then hidden.
- `UpdateMenuItems()` this can be overriden per menu to update items based on changes to your application, such as showing hidden menu items if they're now needed.
- `ShowMenuItem(id)` this can be used to show hidden menu items, most commonly in the method above. This uses the unique id given to the menu item.
- `HideMenuItem(id)` this can be used to hide menu items.

#### MenuItem
This is the class used to define items for the menus in your system. 
It has two constructors one for if the item is a sub menu and another for if its an action. 
These should be called like this: `New MenuItem(id, description, subMenu or action)`
##### Methods
- `Hide()` which is used on menu items, to hide them from the list.
- `Show()` which is used on hidden menu items, to show them in the list.
- `SetAsExitOption()` which is used to set menu items as the exit option for a menu, either going to the parent menu, or exiting the application.

## Example
#### Main Class
```vb
Module Program
    Sub Main(args As String())
        Dim mainMenu = New MainMenu()
        mainMenu.Display()
    End Sub
End Module
```
#### Main Menu Class
```vb
Public Class MainMenu
    Inherits AbstractMenu
    
    public Sub New()
        MyBase.New("Welcome to the main menu.")
    End Sub
    
    Protected Overrides Sub Init()
        AddMenuItem(New MenuItem(0, "Exit menu", action := Nothing).SetAsExitOption())
        AddMenuItem(New MenuItem(1, "Print Hello World", Sub() 
            Console.WriteLine("Hello World!")
            End Sub
        ))
    End Sub
End Class
```

#### Output
```text
Welcome to the main menu
0. Exit menu
1. Print Hello World
Select option: 1
Hello World!

Welcome to the main menu
0. Exit menu
1. Print Hello World
Select option: 0

```

Look in LibraryTest for a better example implementation of the library.
