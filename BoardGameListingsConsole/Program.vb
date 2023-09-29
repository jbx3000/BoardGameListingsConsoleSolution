Imports System
Imports System.Console
Imports System.Net.Http
Imports ConsoleTables
Imports GameListerHelper

Module Program
    Sub Main(args As String())

        Dim helper As New GameHelper      '
        Dim gameList As New List(Of GameModel)
        Dim newGame = New GameModel With {.Title = "New game", .Year = 2023}
        Dim table As New ConsoleTable
        Dim headers As String() = {"Title", "Year Published", "Genre"}

        gameList = helper.LoadGameList()


        helper.DisplayCurrentGameList(table, headers, True)

        Write("press any key to continue")

        ReadKey()

        WriteLine("Adding another game...")

        AddNewGame(gameList, helper)


        'Dim fileOutStr As String = ""

        'For Each game In gameList
        '    fileOutStr += game.GetAllGameInfo
        'Next

        'TextFileAccess.WriteStringToTextFile(fileOutStr, "games.txt")

        helper.DisplayCurrentGameList(table, headers)



        'helper.GetKeyStroke()

        'extra table construction values written in c#
        'Dim rows = Enumerable.Repeat(New Something(), 10)
        'ConsoleTable.From<Something>(rows).Configure(o => o.NumberAlignment = Alignment.Right).Write(Format.Alternative)

    End Sub

    Public Sub AddNewGame(gameList As List(Of GameModel), helper As GameHelper)

        Dim newGame As New GameModel

        WriteLine("Add a new game...")

        Write("Enter game Title: ")
        Dim gameTitle = ReadLine()

        Write("Enter year game published: ")
        Dim gameYear = ReadLine()

        If gameTitle.Length > 50 Or gameYear.Length <> 4 Then
            WriteLine("Title must be less than 50 characters in length")
            WriteLine("Year published must be 4 characters in length")
            WriteLine()
            Write("Press any key to continue")
            ReadKey()
        Else
            newGame.Title = gameTitle
            newGame.Year = gameYear
            gameList.Add(newGame)
            helper.SaveGamelistToFile(gameList)
        End If

    End Sub

End Module
