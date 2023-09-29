

Public Class GameModel

    Private gameTitle As String

    Public Property Title() As String
        Get
            Return gameTitle
        End Get
        Set(ByVal value As String)
            gameTitle = value
        End Set
    End Property

    Private gameYear As Integer

    Public Property Year() As Integer
        Get
            Return gameYear
        End Get
        Set(ByVal value As Integer)
            gameYear = value
        End Set
    End Property

    Public Function GetAllGameInfo() As String
        Return gameTitle & " " & gameYear
    End Function

End Class
