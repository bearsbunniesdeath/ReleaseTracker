Public Class ReleaseWindow : Inherits AppWindowBase
    Public Sub New(releaseViewModel As ReleaseWindowViewModel)
        InitializeComponent()

        Me.Owner = Application.Current.MainWindow
        Me.DataContext = releaseViewModel
    End Sub
End Class
