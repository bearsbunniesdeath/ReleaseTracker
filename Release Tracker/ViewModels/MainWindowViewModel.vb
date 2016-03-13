Imports System.ComponentModel
Imports System.Configuration
Imports System.Collections.ObjectModel

Public Class MainWindowViewModel
    Inherits ViewModelBase

#Region "Fields"
    Private Shared _releaseColl As ObservableCollection(Of Release)

    Private _releaseDB As ReleaseDBAdapter

    Private _selectedRow As Release
#End Region

#Region "Commands"
    Private _closeApp As ICommand

    Private _add As ICommand
    Private _edit As ICommand
    Private _delete As ICommand
#End Region

    Public Sub New()
        Dim binFilePath As String
        binFilePath = ConfigurationManager.AppSettings("ReleaseBinString").ToString()
        _releaseDB = New ReleaseDBAdapter(binFilePath)
        _releaseColl = _releaseDB.GetAllReleases()

        CloseApp = New RelayCommand(Sub()
                                        Application.Current.Shutdown()
                                    End Sub)
        Add = New RelayCommand(Sub()
                                   Dim release As Release = New Release()
                                   Dim releaseViewModel As ReleaseWindowViewModel = New ReleaseWindowViewModel(release, gReleaseWinMode.Add)
                                   Dim releaseWindow As ReleaseWindow
                                   releaseWindow = New ReleaseWindow(releaseViewModel)

                                   AddHandler releaseViewModel.AddNewRelease, AddressOf OnAddNewRelease
                                   releaseWindow.ShowDialog()
                               End Sub)
        Edit = New RelayCommand(Sub()
                                    If Not _selectedRow Is Nothing Then
                                        Dim releaseViewModel As ReleaseWindowViewModel = New ReleaseWindowViewModel(_selectedRow, gReleaseWinMode.Edit)
                                        Dim releaseWindow As ReleaseWindow
                                        releaseWindow = New ReleaseWindow(releaseViewModel)

                                        AddHandler releaseViewModel.EditRelease, AddressOf OnEditRelease
                                        releaseWindow.ShowDialog()
                                    End If
                                End Sub)

        Delete = New RelayCommand(Sub()
                                      'DeleteRelease(_selectedRow)
                                  End Sub)


    End Sub

#Region "Properties"

    Public Property CloseApp() As ICommand
        Get
            CloseApp = _closeApp
        End Get
        Set(value As ICommand)
            _closeApp = value
        End Set
    End Property

    Public Property Add() As ICommand
        Get
            Add = _add
        End Get
        Set(value As ICommand)
            _add = value
        End Set
    End Property

    Public Property Edit() As ICommand
        Get
            Edit = _edit
        End Get
        Set(value As ICommand)
            _edit = value
        End Set
    End Property

    Public Property Delete() As ICommand
        Get
            Delete = _delete
        End Get
        Set(value As ICommand)
            _delete = value
        End Set
    End Property

    Public ReadOnly Property AppVersion As String
        Get
            AppVersion = gAppVersion
        End Get
    End Property

    Public Property ReleaseColl As ObservableCollection(Of Release)
        Get
            ReleaseColl = _releaseColl
        End Get
        Set(value As ObservableCollection(Of Release))
            _releaseColl = value
        End Set
    End Property

    Public Property SelectedRow As Release
        Get
            SelectedRow = _selectedRow
        End Get
        Set(value As Release)
            _selectedRow = value
        End Set
    End Property

#End Region

#Region "Methods"

    Public Sub AddNewRelease(release As Release, Optional idx As Integer = -1)
        If idx < 0 Then
            _releaseColl.Add(release)
        Else
            _releaseColl.Insert(idx, release)
        End If
        _releaseDB.SaveAllReleases(_releaseColl)
    End Sub

    Private Sub OnAddNewRelease(sender As Object, e As ReleaseEventArgs)
        'TODO: Add some checking here or ReleaseWindowViewModel??
        AddNewRelease(e.Release)
    End Sub

    Public Sub EditRelease(release As Release)
        Dim idx As Integer = _releaseColl.IndexOf(_selectedRow)
        _releaseColl.RemoveAt(idx)
        AddNewRelease(release, idx)
    End Sub

    Private Sub OnEditRelease(sender As Object, e As ReleaseEventArgs)
        EditRelease(e.Release)
    End Sub

#End Region

End Class
