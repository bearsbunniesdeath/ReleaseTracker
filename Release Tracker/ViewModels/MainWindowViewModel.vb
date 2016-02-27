Imports System.ComponentModel

Public Class MainWindowViewModel
    Implements INotifyPropertyChanged

    Private Const _appVersion As String = "Release Tracker v1.0"

    'Commands
    Private _closeApp As ICommand

    Public Sub New()
        CloseApp = New RelayCommand(Sub()
                                        Application.Current.Shutdown()
                                    End Sub)
    End Sub

    Private Event INotifyPropertyChanged_PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Property CloseApp() As ICommand
        Get
            CloseApp = _closeApp
        End Get
        Set(value As ICommand)
            _closeApp = value
        End Set
    End Property

    Public ReadOnly Property AppVersion() As String
        Get
            AppVersion = _appVersion
        End Get
    End Property

End Class

Public Class RelayCommand
    Implements ICommand

    Public Custom Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged
        AddHandler(value As EventHandler)
            If IsNothing(Me._canExecuteEvaluator) = False Then
                AddHandler CommandManager.RequerySuggested, value
            End If
        End AddHandler
        RemoveHandler(value As EventHandler)
            If IsNothing(Me._canExecuteEvaluator) = False Then
                AddHandler CommandManager.RequerySuggested, value
            End If
        End RemoveHandler
        RaiseEvent(sender As Object, e As EventArgs)
        End RaiseEvent
    End Event
    Private _methodToExecute As Action
    Private _canExecuteEvaluator As Func(Of Boolean)
    Public Sub New(ByRef methodToExecute As Action, ByRef canExecuteEvaluator As Func(Of Boolean))
        Me._methodToExecute = methodToExecute
        Me._canExecuteEvaluator = canExecuteEvaluator
    End Sub
    Public Sub New(ByRef methodToExecute As Action)
        Me.New(methodToExecute, Nothing)
    End Sub
    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        If IsNothing(Me._canExecuteEvaluator) Then
            Return True
        Else
            Dim result As Boolean = Me._canExecuteEvaluator.Invoke()
            Return result
        End If
    End Function
    Public Sub Execute(parameter As Object) Implements ICommand.Execute
        Me._methodToExecute.Invoke()
    End Sub
End Class
