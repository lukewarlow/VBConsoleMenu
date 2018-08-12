Public MustInherit Class AbstractMenu
    Private Title As String
    
    Private ReadOnly MenuItems As List(Of MenuItem)

    Protected Sub New(title As String)
        Me.Title = title
        MenuItems = New List(Of MenuItem)
        Init()
    End Sub
    
    Protected MustOverride Sub Init()
    
    Protected Overridable Sub UpdateMenuItems()
        
    End Sub
    
    Public Sub Display()
        Dim repeat = True
        While (repeat)
            UpdateMenuItems()
            Console.WriteLine()
            Console.WriteLine(Title)
            For i = 0 To MenuItems.Count Step 1
                If (MenuItems(i).IsVisible)
                    Console.WriteLine(i + ". " + MenuItems(i).Description)
                End If
            Next
            
            Console.Write("Select Option: ")
            Dim input = Console.ReadLine()
            
            Try
                Dim itemIndex = Int32.Parse(input)
                Dim menuItem = MenuItems(itemIndex)
                If (menuItem.IsVisible)
                    repeat = menuItem.Run()
                Else 
                    Throw New InvalidOperationException()
                End If
            Catch e As FormatException
                Console.WriteLine("Invalid option, you need to enter a number.")
                repeat = True
            Catch e As ArgumentOutOfRangeException
                Console.WriteLine($"Invalid option. Option {input} doesn't exist.")
                repeat = True
            Catch e As InvalidOperationException
                Console.WriteLine($"Invalid option. Option {input} is hidden.")
                repeat = True
            End Try
            
        End While
    End Sub
    
    Public Sub AddMenuItem(menuItem As MenuItem)
        If (Not MenuItems.Contains(menuItem))
            MenuItems.Add(menuItem)
        Else 
            Throw New ArgumentException($"Menu item with id {menuItem.Id} already exists!")
        End If
    End Sub
    
    Public Sub AddHiddenMenuItem(menuItem As MenuItem)
        AddMenuItem(menuItem.Hide())
    End Sub

    Public Sub ShowMenuItem(itemId As Long)
        Try
            Dim menuItem = New MenuItem(itemId)
            Dim index = MenuItems.IndexOf(menuItem)
            MenuItems(index).Show()
        Catch e As ArgumentOutOfRangeException
            Throw New ArgumentException($"Error showing menu item. Menu item with ID {itemId} hasn't been added to this menu.")
        End Try
    End Sub
    
    Public Sub HideMenuItem(itemId As Long)
        Try
            Dim menuItem = New MenuItem(itemId)
            Dim index = MenuItems.IndexOf(menuItem)
            MenuItems(index).Show()
        Catch e As ArgumentOutOfRangeException
            Throw New ArgumentException($"Error hiding menu item. Menu item with ID {itemId} hasn't been added to this menu.")
        End Try
    End Sub
End Class