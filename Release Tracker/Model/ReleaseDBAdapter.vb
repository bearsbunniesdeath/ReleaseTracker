Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Linq
Imports System.Collections.ObjectModel

Public Class ReleaseDBAdapter : Inherits Serializer(Of List(Of Release))

#Region "Fields"

#End Region

    Public Sub New(filePath As String)
        MyBase.New(filePath)
    End Sub

    Public Function GetAllReleases() As ObservableCollection(Of Release)
        Dim objFromBin As List(Of Release)

        objFromBin = LoadFromFile()
        If Not objFromBin Is Nothing Then
            Return New ObservableCollection(Of Release)(objFromBin)
        End If
        Return New ObservableCollection(Of Release)
    End Function

    Public Sub SaveAllReleases(collection As ObservableCollection(Of Release))
        Dim list As List(Of Release)
        list = collection.ToList()
        SaveToFile(list)
    End Sub

    Public Function GetRelease(releaseID As Integer)
        Throw New NotImplementedException
    End Function

    Public Sub UpdateRelease(ReleaseObj As Release)
        Throw New NotImplementedException
    End Sub

End Class
