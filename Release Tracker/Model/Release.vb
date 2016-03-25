Imports Microsoft.VisualBasic

<Serializable()>
Public Class Release

#Region "Fields"

    Private _id As Integer            'Release ID
    Private _name As String           'Release name
    Private _type As gReleaseType
    Private _date As Date

#End Region

    Public Sub New()
        Me.Name = "New Release"
        Me.ReleaseDate = DateTime.Today
    End Sub

#Region "Properties"
    Public Property ID As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property Name As String
        Get
            Return _name
        End Get
        Set(value As String)
            If Not value Is Nothing And Not (value = "") Then
                _name = value
            End If
        End Set
    End Property

    Public Property Type As gReleaseType
        Get
            Return _type
        End Get
        Set(value As gReleaseType)
            _type = value
        End Set
    End Property

    Public Property ReleaseDate As Date
        Get
            Return _date
        End Get
        Set(value As Date)
            Dim currentDate As Date
            currentDate = DateTime.Today
            If value >= currentDate Then
                _date = value
            End If
        End Set
    End Property

    Public ReadOnly Property DaysTillRelease As Integer
        Get
            Dim tSpan As TimeSpan = _date - DateTime.Today
            Return tSpan.Days
        End Get
    End Property

    Public ReadOnly Property CountdownString As String
        Get
            Dim daysLeft As Integer
            'TODO: Check the "state" and use that
            daysLeft = DaysTillRelease
            If daysTillRelease > 45 Then  'Prevents 'one months' from showing up
                Return String.Format("{0} (~{1:0} months)", daysTillRelease.ToString(), daysTillRelease / 30.45)
            ElseIf daysTillRelease <= 0 Then
                Return "Released"
            Else
                Return daysTillRelease.ToString()
            End If
        End Get
    End Property

    Public ReadOnly Property State As String
        Get
            'TODO: Use an enum for this
            Dim daysLeft As Integer
            daysLeft = DaysTillRelease()
            If daysLeft > 45 Then
                Return "Red"
            ElseIf daysLeft <= 0 Then
                Return "Green"
            Else
                Return "Yellow"
            End If

        End Get
    End Property

#End Region


End Class
