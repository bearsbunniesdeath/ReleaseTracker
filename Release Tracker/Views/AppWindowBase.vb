Imports MahApps.Metro.Controls

Public MustInherit Class AppWindowBase : Inherits MetroWindow
    Public Sub New()
        AddHandler Me.DataContextChanged, AddressOf Me.OnDataContextChanged
    End Sub

    Private Sub OnDataContextChanged(sender As Object, e As DependencyPropertyChangedEventArgs)
        If TypeOf e.NewValue Is ViewModelBase Then
            AddHandler CType(e.NewValue, ViewModelBase).RequestClose, AddressOf Me.Close
        Else
            Throw New InvalidCastException("DataContext must be an instance of ViewModelBase.")
        End If
    End Sub
End Class
