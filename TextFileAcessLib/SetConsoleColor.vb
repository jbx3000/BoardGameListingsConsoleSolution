

Public Class SetConsoleColor

    Public Shared Sub setColorCyanDarkblue()
        Console.ForegroundColor = ConsoleColor.Cyan
        Console.BackgroundColor = ConsoleColor.DarkBlue
    End Sub

    Public Shared Sub resetColors()
        Console.ResetColor()
    End Sub

End Class
