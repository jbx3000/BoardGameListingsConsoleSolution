

Imports System.IO
Imports System.Windows

Public Class TextFileAccess


    ''' <summary>
    ''' Opens file, read entire contents as string, trims all CR and LF from end of string, close file
    ''' Will throw a custom exception message if file not found
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <returns>File contents as one string</returns>
    Public Shared Function ReadFile(ByVal fileName As String) As String
        Try
            Dim myReader As StreamReader = New StreamReader(fileName)
            Dim line As String

            line = myReader.ReadToEnd()

            line = RemoveCrAndLfFromEndOfString(line)

            myReader.Close()

            Return line

        Catch ex As Exception
            Throw New FileNotFoundException($"A problem occurred:{vbCrLf}{ex.Message}")
        End Try

    End Function

    ' trims all CR and LF from end of input text string to be written to file
    Public Shared Sub WriteStringToTextFile(ByVal input As String, filename As String)

        'Dim trimmedStr As String = input.TrimEnd(vbCrLf) 'does not work

        input = RemoveCrAndLfFromEndOfString(input)

        File.WriteAllText(filename, input)

    End Sub

    Public Shared Function RemoveCrAndLfFromEndOfString(input As String) As String
        If input.EndsWith(vbCrLf) Then
            Dim oTrim() As Char = {vbCr, vbLf}
            input = input.TrimEnd(oTrim)
        End If

        Return input
    End Function
End Class
