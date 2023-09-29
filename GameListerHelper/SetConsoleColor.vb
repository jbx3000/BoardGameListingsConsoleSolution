

Imports System.Text.RegularExpressions

Public Class SetConsoleColor

    Public Shared Sub setTitleColor()
        Console.ForegroundColor = ConsoleColor.Cyan
        Console.BackgroundColor = ConsoleColor.DarkBlue
    End Sub

    Public Shared Sub resetColors()
        Console.ResetColor()
    End Sub

    Public Shared Sub SetNumericCharsInStringToWhite(inputStr As String)

        'If Regex.IsMatch(myString, "^[A-Za-z0-9]+$") Then
        '    'Do stuff
        'End If
        'EDIT:   I forgot to add the ^ And the $ to denote that the match should go from start to finish on the string.
        'You'll also need to put a \s in there if whitespace is allowed.

        For Each ch In inputStr
            If ch >= "0" And ch <= "9" Then
                Console.ForegroundColor = System.ConsoleColor.White
                Console.Write(ch)
            Else
                Console.ForegroundColor = System.ConsoleColor.Green
                Console.Write(ch)
            End If
        Next

        'Console.WriteLine()
        'resetColors()
    End Sub

End Class
