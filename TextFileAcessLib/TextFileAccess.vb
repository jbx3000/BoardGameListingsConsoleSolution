

Imports System.IO

Public Class TextFileAccess


    ''' <summary>
    ''' Opens file, read entire contents as string, close file
    ''' Will throw a custom exception message if file not found
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <returns>File contents as one string</returns>
    Public Shared Function ReadFile(ByVal fileName As String) As String
        Try
            Dim myReader As StreamReader = New StreamReader(fileName)
            Dim line As String

            line = myReader.ReadToEnd()

            myReader.Close()

            Return line

        Catch ex As Exception
            Throw New FileNotFoundException($"A problem occured:{vbCrLf}{ex.Message}")
        End Try

    End Function

    Public Shared Sub WriteStringToTextFile(input As String, filename As String)

        File.WriteAllText(filename, input)

    End Sub

End Class
