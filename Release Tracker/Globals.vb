Public Module Globals

    Public gAppVersion As String = $"Release Tracker v {Reflection.Assembly.GetExecutingAssembly.GetName().Version.ToString()}"

    Public Enum gReleaseType
        Games
        Movies
        Music
        TV
    End Enum

    Public Enum gReleaseWinMode
        Add
        Edit
    End Enum

    <Flags>
    Public Enum gReleaseFilter
        All = 1
        Games = 2
        Movies = 4
        Music = 8
        TV = 16
    End Enum

End Module
