Imports System.ComponentModel

Public MustInherit Class ViewModelBase
    Implements INotifyPropertyChanged

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Public Event RequestClose As EventHandler


    Public Sub NotifyPropertyChanged(ByVal info As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
    End Sub

    Public Sub CloseWindow()
        RaiseEvent RequestClose(Me, Nothing)
    End Sub

End Class
