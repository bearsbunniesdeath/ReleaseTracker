Imports System.ComponentModel
Imports System.Data
Imports System.Configuration
Imports System.Collections.ObjectModel

Public Class MainWindowViewModel
    Inherits ViewModelBase

#Region "Fields"
    Private Shared _releaseColl As ObservableCollection(Of Release)

    Private _releaseDB As ReleaseDBAdapter
#End Region

#Region "Commands"
    Private _closeApp As ICommand

    Private _addRelease As ICommand
    Private _editRelease As ICommand
#End Region

    Public Sub New()
        Dim binFilePath As String
        binFilePath = ConfigurationManager.AppSettings("ReleaseBinString").ToString()
        _releaseDB = New ReleaseDBAdapter(binFilePath)
        _releaseColl = _releaseDB.GetAllReleases()

        CloseApp = New RelayCommand(Sub()
                                        Application.Current.Shutdown()
                                    End Sub)
        AddRelease = New RelayCommand(Sub()
                                          Dim release As Release = New Release()
                                          Dim releaseViewModel As ReleaseWindowViewModel = New ReleaseWindowViewModel(release)
                                          Dim releaseWindow As ReleaseWindow
                                          releaseWindow = New ReleaseWindow(releaseViewModel)

                                          AddHandler releaseViewModel.AddNewRelease, AddressOf HandleAddNewRelease
                                          releaseWindow.ShowDialog()
                                      End Sub)

    End Sub

    Public Property CloseApp() As ICommand
        Get
            CloseApp = _closeApp
        End Get
        Set(value As ICommand)
            _closeApp = value
        End Set
    End Property

    Public Property AddRelease As ICommand
        Get
            AddRelease = _addRelease
        End Get
        Set(value As ICommand)
            _addRelease = value
        End Set
    End Property

    Public ReadOnly Property AppVersion() As String
        Get
            AppVersion = gAppVersion
        End Get
    End Property

    Public Property ReleaseColl() As ObservableCollection(Of Release)
        Get
            ReleaseColl = _releaseColl
        End Get
        Set(value As ObservableCollection(Of Release))
            _releaseColl = value
        End Set
    End Property

    Private Sub HandleAddNewRelease(sender As Object, release As Release)
        'TODO: Add some checking here or ReleaseWindowViewModel??
        _releaseColl.Add(release)
        _releaseDB.SaveAllReleases(_releaseColl)
    End Sub

End Class
