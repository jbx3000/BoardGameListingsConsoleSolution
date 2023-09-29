
Imports System.Console
Imports System.Net.Http
Imports ConsoleTables
Imports GameListerHelper

Public Class GameHelper

    Public Sub SaveGamelistToFile(gameList As List(Of GameModel))

        Dim fileOutStr As String = ""

        For Each game In gameList
            fileOutStr += game.GetAllGameInfo
        Next

        TextFileAccess.WriteStringToTextFile(fileOutStr, "games.txt")

    End Sub

    ''' <summary>
    ''' Call with string array of header text, amount of headers is variable
    ''' </summary>
    ''' <param name="titleHeaders"></param>
    ''' <returns>loads the ConsoleTable with a variable # of headers and returns the ConsoleTable object</returns>
    Public Function CreateTableWithTableHeaders(titleHeaders() As String) As ConsoleTable
        Dim headerStr As String = String.Join(",", titleHeaders)
        Return New ConsoleTable(titleHeaders)
    End Function

    ''' <summary>
    ''' Puts the current list of games into the game table used for display
    ''' </summary>
    ''' <param name="gmList">current list of games</param>
    ''' <param name="tbl">table of games to be displayed in table format</param>
    Public Sub LoadGameListToDisplayTable(gmList As List(Of GameModel), tbl As ConsoleTable)
        For Each game In gmList
            tbl.AddRow(game.Title, game.Year, "N/A")
        Next
    End Sub
    ''' <summary>
    ''' Loads list of saved games from file 
    ''' </summary>
    ''' <returns>List of all saved GameModel objects</returns>
    Public Function LoadGameList() As List(Of GameModel)
        Dim gameInfo As String = TextFileAccess.ReadFile("games.txt")    ' reads entire text file as one long string
        Return LongStringToGameModelArray(gameInfo) 'gameList contains all the saved games in GameModel format
    End Function

    ''' <summary>
    ''' Assumes each game record in file contains 2 records, 1 item in a record per newline
    ''' </summary>
    ''' <param name="fileString"></param>
    ''' <returns>New List(Of GameModel)</returns>
    Public Function LongStringToGameModelArray(fileString As String) As List(Of GameModel)

        Dim gameList As New List(Of GameModel)

        Dim gameStrArray() As String = fileString.Split(vbCrLf)

        'Console.WriteLine("gameStrArray begin ")
        'For Each myStr In gameStrArray
        '    Console.WriteLine(myStr)
        'Next
        'Console.WriteLine("gameStrArray end")

        For i = 0 To gameStrArray.Length - 1 Step 2

            Dim gm As New GameModel

            gm.Title = gameStrArray(i)
            gm.Year = gameStrArray(i + 1)

            gameList.Add(gm)
        Next

        Return gameList

    End Function

    ''' <summary>
    ''' Sets color of numeric characters in input string to white 
    ''' Sets other characters to green
    ''' Displays line to screen and resets console colors
    ''' </summary>
    ''' <param name="menu"></param>
    Public Sub DisplayMenu(menu As String)
        SetConsoleColor.SetNumericCharsInStringToWhite(menu)
        Console.WriteLine()
        SetConsoleColor.resetColors()
    End Sub
    ''' <summary>
    ''' Displays optional welcome method, program Menu and List of games in table format 
    ''' </summary>
    ''' <param name="helperMethods">helperMethods as GameHelper object</param>
    ''' <param name="tbl">ConsoleTable object</param>
    ''' <param name="headers">table column headers as an array of Strings</param>
    ''' <param name="displayWelcome">boolean as to whether to display welcome message</param>
    Public Sub DisplayCurrentGameList(tbl As ConsoleTable, headers As String(), Optional displayWelcome As Boolean = False)

        'Clear screen
        Console.Clear()
        If displayWelcome Then
            SetConsoleColor.setTitleColor()
            Console.WriteLine("Welcome to a Listing of Boardgames")
            SetConsoleColor.resetColors()
        End If

        Dim gameList As New List(Of GameModel)
        ' display menu
        DisplayMenu("Press 1: Add a game to list  2: Delete a game from list 3: Exit")

        'load file data to list of GameModel Objects
        gameList = LoadGameList()

        'create new table with headers defined at top 
        tbl = CreateTableWithTableHeaders(headers)

        'load list of games into tbl
        LoadGameListToDisplayTable(gameList, tbl)

        'display table
        tbl.Write()
    End Sub

    Public Sub GetKeyStroke()
        Dim keyInput As ConsoleKeyInfo

        Do
            keyInput = Console.ReadKey()

            Console.WriteLine()

            Select Case keyInput.KeyChar
                Case "1"
                    WriteLine("You pressed 1")
                Case "2"
                    WriteLine("You pressed 2")
                Case "3"
                    WriteLine("You pressed 3 which is the exit key")
                Case vbNullChar
                    'arrow keys KeyChar value is vbNullChar
                    WriteLine("You pressed a key whos KeyChar value is vbNullChar")
                Case Else
                    WriteLine("You pressed a key other than 1, 2 or 3")
            End Select

        Loop Until keyInput.KeyChar = "3"

    End Sub

End Class
