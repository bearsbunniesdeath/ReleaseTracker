Public Class ReleaseEventArgs : Inherits System.EventArgs

    Public Release As Release
    Public Index As Integer

    Public Sub New(rel As Release, Optional idx As Integer = -1)
        Release = rel
        Index = idx
    End Sub

End Class
