Public Class ReleaseWindowViewModel
    Inherits ViewModelBase

#Region "Fields"
    Private _releaseObj As Release
    Private _mode As gReleaseWinMode

    Public Event AddNewRelease(sender As Object, e As ReleaseEventArgs)
    Public Event EditRelease(sender As Object, e As ReleaseEventArgs)
#End Region

#Region "Commands"
    Private _add As ICommand
    Private _edit As ICommand
    Private _cancel As ICommand
#End Region
 _
    Public Sub New(ByVal releaseObj As Release, mode As gReleaseWinMode)
        _releaseObj = releaseObj
        _mode = mode

        Add = New RelayCommand(Sub()
                                   RaiseEvent AddNewRelease(Me, New ReleaseEventArgs(_releaseObj))
                                   CloseWindow()
                               End Sub)

        Edit = New RelayCommand(Sub()
                                    RaiseEvent EditRelease(Me, New ReleaseEventArgs(_releaseObj))
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
            RaisePropertyChanged(NameOf(Name))
        End Set
    End Property

    Public Property SelectedType As gReleaseType
        Get
            SelectedType = _releaseObj.Type
        End Get
        Set(value As gReleaseType)
            _releaseObj.Type = value
            RaisePropertyChanged(NameOf(SelectedType))
        End Set
    End Property

    Public Property ReleaseDate As Date
        Get
            ReleaseDate = _releaseObj.ReleaseDate
        End Get
        Set(value As Date)
            _releaseObj.ReleaseDate = value
            RaisePropertyChanged(NameOf(ReleaseDate))
        End Set
    End Property

    Public ReadOnly Property Types As Array
        Get
            Return [Enum].GetValues(GetType(gReleaseType))
        End Get
    End Property

    Public ReadOnly Property Commit As ICommand
        Get
            If _mode = gReleaseWinMode.Add Then
                Commit = _add
            ElseIf _mode = gReleaseWinMode.Edit Then
                Commit = _edit
            Else
                Throw New Exception("Unknown release window mode.")
            End If
        End Get
    End Property

    Public Property Add As ICommand
        Get
            Add = _add
        End Get
        Set(value As ICommand)
            _add = value
        End Set
    End Property

    Public Property Edit As ICommand
        Get
            Edit = _edit
        End Get
        Set(value As ICommand)
            _edit = value
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

    Public ReadOnly Property WinMode As gReleaseWinMode
        Get
            WinMode = _mode
        End Get
    End Property
#End Region

End Class
