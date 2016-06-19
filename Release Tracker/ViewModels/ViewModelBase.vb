Imports GalaSoft

Public MustInherit Class ViewModelBase
    Inherits MvvmLight.ViewModelBase

    Public Event RequestClose As EventHandler

    Public Sub CloseWindow()
        RaiseEvent RequestClose(Me, Nothing)
    End Sub

End Class
