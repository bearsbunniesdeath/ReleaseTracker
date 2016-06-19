Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Release_Tracker

<TestClass()> Public Class ReleaseTests

    <TestMethod()> Public Sub TestTomorrowRelease()
        Dim release = New Release()
        release.ReleaseDate = DateTime.Now.AddDays(1)
        Assert.IsTrue(release.DaysTillRelease = 1)
    End Sub

    <TestMethod()> Public Sub TestTodayRelease()
        Dim release = New Release()
        release.ReleaseDate = DateTime.Now
        Assert.IsTrue(release.DaysTillRelease = 0)
    End Sub

End Class