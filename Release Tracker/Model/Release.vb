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
        Me.ReleaseDate = DateTime.Now
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
            currentDate = DateTime.Now
            If value > currentDate Then
                _date = value
            End If
        End Set
    End Property

#End Region


End Class
