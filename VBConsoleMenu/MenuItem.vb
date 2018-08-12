Public Class MenuItem
    Public Dim Id As Long
    Public Dim Description As String
    Public Dim IsVisible As Boolean
    Private Dim IsExitOption As Boolean
    
    Private ReadOnly _menu As AbstractMenu
    Private ReadOnly _action As Action
    
    Public Sub New(id As Long)
        Me.Id = id
        Show()
    End Sub

    Public Sub New(id As Long, description As String, action As Action)
        Me.Id = id
        Me.Description = description
        _action = action
        Show()
    End Sub
    
    Public Sub New(id As Long, description As String, menu As AbstractMenu)
        Me.Id = id
        Me.Description = description
        _menu = menu
        Show()
    End Sub
    
    Public Function Hide() As MenuItem
        IsVisible = False
        Return Me
    End Function
    
    Public Function Show() As MenuItem
        IsVisible = True
        Return Me
    End Function
    
    Public Function SetAsExitOption() As MenuItem
        IsExitOption = True
        Return Me
    End Function
    
    Public Function Run() As Boolean
        If (Not _menu Is Nothing)
            _menu.Display()
        Else 
            _action?.Invoke()
        End If
        Return IsExitOption
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        If (obj.Equals(Me))
            Return True
        ElseIf (TypeOf obj IsNot MenuItem)
            Return False
        End If
        
        Dim menuItem = CType(obj, MenuItem)
        Return menuItem.Id.Equals(Id)
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return Id.GetHashCode()
    End Function
End Class
