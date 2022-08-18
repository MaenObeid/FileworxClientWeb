Public Class ApplicationSettings

    Public Const usersDirectory = "Users"
    Public Const newsDirectory = "News"
    Public Const photosDirectory = "Photos"
    Public Const imagesDirectory = "Images"
    Public Const lambda = "~"

    Public Const separator = "%@$#$**%$"

    Public Shared currentUserName As String

    Public Shared postsMenu As New List(Of Post)
    Public Shared usersList As New List(Of User)

    Private Sub New()
    End Sub

End Class
