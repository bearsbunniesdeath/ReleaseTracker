Imports Microsoft.VisualBasic
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO

Public MustInherit Class Serializer(Of T)

    Private _binFormatter As BinaryFormatter
    Private _fileStream As Stream
    Private _filePath As String

    Public Sub New(filePath As String)
        _filePath = filePath
        _binFormatter = New BinaryFormatter
    End Sub

    Protected Sub SaveToFile(obj As T)
        _OpenStream()
        _binFormatter.Serialize(_fileStream, obj)
        _CloseStream()
    End Sub

    Protected Function LoadFromFile() As T
        Dim retVal As Object = Nothing
        _OpenStream()
        Try
            retVal = _binFormatter.Deserialize(_fileStream)
        Catch
        End Try
        _CloseStream()
        Return retVal
    End Function

    Private Sub _OpenStream()
        _fileStream = File.Open(_filePath, FileMode.OpenOrCreate)
    End Sub

    Private Sub _CloseStream()
        _fileStream.Close()
    End Sub

    Public ReadOnly Property FilePath As String
        Get
            Return _filePath
        End Get
    End Property

End Class
