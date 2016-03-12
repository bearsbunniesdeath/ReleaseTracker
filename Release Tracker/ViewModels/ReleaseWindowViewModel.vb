Public Class ReleaseWindowViewModel
    Inherits ViewModelBase

#Region "Fields"
    Private _releaseObj As Release

    Public Event AddNewRelease(sender As Object, release As Release)
#End Region

#Region "Commands"
    Private _add As ICommand
    Private _cancel As ICommand
#End Region
 _
    Public Sub New(releaseObj As Release)
        _releaseObj = releaseObj

        Add = New RelayCommand(Sub()
                                   RaiseEvent AddNewRelease(Me, _releaseObj)
                                   CloseWindow()
                               End Sub)
        Cancel = New RelayCommand(Sub()
                                      CloseWindow()
                                  End Sub)
    End Sub

#Region "Properties"
    Public Property Name As String
        Get
            Name = _releaseObj.Name
        End Get
        Set(value As String)
            _releaseObj.Name = value
            NotifyPropertyChanged("Name")
        End Set
    End Property

    Public Property Type As gReleaseType
        Get
            Type = _releaseObj.Type
        End Get
        Set(value As gReleaseType)
            _releaseObj.Type = value
            NotifyPropertyChanged("Type")
        End Set
    End Property

    Public Property Add As ICommand
        Get
            Add = _add
        End Get
        Set(value As ICommand)
            _add = value
        End Set
    End Property

    Public Property Cancel As ICommand
        Get
            Cancel = _cancel
        End Get
        Set(value As ICommand)
            _cancel = value
        End Set
    End Property
#End Region

End Class
