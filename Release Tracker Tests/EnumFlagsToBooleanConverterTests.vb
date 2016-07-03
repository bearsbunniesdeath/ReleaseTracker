Imports Release_Tracker

<TestClass()> Public Class EnumFlagsToBooleanConverterTests

    Dim converter As New EnumFlagsToBooleanConverter

    <TestMethod> Public Sub TestZeroValueFlags()
        Dim flags As gReleaseFilter = 0
        Dim value As Boolean = converter.Convert(flags, GetType(gReleaseFilter), gReleaseFilter.Games, Nothing)
        Assert.IsFalse(value)
    End Sub

    <TestMethod> Public Sub TestTrueWithOneFlag()
        Dim flags As gReleaseFilter = gReleaseFilter.Movies
        Dim value As Boolean = converter.Convert(flags, GetType(gReleaseFilter), gReleaseFilter.Movies, Nothing)
        Assert.IsTrue(value)
    End Sub

    <TestMethod> Public Sub TestTrueWithMultipleFlags()
        Dim flags As gReleaseFilter = gReleaseFilter.TV Or gReleaseFilter.Music
        Dim value As Boolean = converter.Convert(flags, GetType(gReleaseFilter), gReleaseFilter.TV, Nothing)
        Assert.IsTrue(value)
    End Sub

End Class
