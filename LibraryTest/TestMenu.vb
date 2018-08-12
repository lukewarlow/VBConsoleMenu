Imports VBConsoleMenu

Public Class TestMenu 
    Inherits AbstractMenu
    
    Dim ShowHiddenMenu As Boolean
    
    public Sub New()
       MyBase.New("Welcome to the test menu.")
    End Sub
    
    Protected Overrides Sub Init()
        AddMenuItem(New MenuItem(0, "Exit menu", action := Nothing).SetAsExitOption())
        AddMenuItem(New MenuItem(1, "Test sub menu", New TestSubMenu))
        AddMenuItem(New MenuItem(2, "Show hidden menu item", Sub()
            Console.WriteLine("Showing hidden menu item")
            ShowHiddenMenu = True
        End Sub))
        
        AddHiddenMenuItem(New MenuItem(3, "Hidden menu item", Sub() 
            Console.WriteLine("I was a hidden menu item")
            End Sub))
        
    End Sub
    
    Protected Overrides Sub UpdateMenuItems()
        If (ShowHiddenMenu)
            ShowMenuItem(3)
        End If
    End Sub
End Class

Public Class TestSubMenu
    Inherits AbstractMenu
    
    public Sub New()
        MyBase.New("Welcome to the test sub menu.")
    End Sub
    
    Protected Overrides Sub Init()
        AddMenuItem(New MenuItem(0, "Exit current menu", action := Nothing).SetAsExitOption())
        AddMenuItem(New MenuItem(1, "Test sub menu item", Sub() 
            Console.WriteLine("Test sub menu item selected")
            End Sub))
    End Sub
End Class
