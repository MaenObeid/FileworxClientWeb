Imports System.IO

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    'Public Shared streamWriter As StreamWriter
    'Public Shared fileStreamWriter As FileStream
    'Public Shared streamReader As StreamReader
    'Public Shared fileStreamReader As FileStream

    'Shared currentDir As String = AppDomain.CurrentDomain.BaseDirectory.ToString.Split("FileworxClientAppWeb")(0)
    'Public Shared usersDirectory As String = currentDir & "FileworxClientAppWeb\Users\"
    'Public Shared newsDirectory As String = currentDir & "FileworxClientAppWeb\News\"
    'Public Shared photosDirectory As String = currentDir & "FileworxClientAppWeb\Photos\"
    'Dim files As ArrayList
    'Dim records As New List(Of Post)


    Function Index() As ActionResult

        Try

            ApplicationFunctions.LoadPosts()

        Catch ex As Exception
            ViewData("Message") = ex.Message.ToString()
        End Try


        Return View(ApplicationSettings.postsMenu)

    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."
        Return View()
    End Function

    Function Contact(s As String) As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function

    Function Delete(i As String) As ActionResult
        'ViewData("Message") = "Your contact page."


        Return RedirectToAction("ViewPost", "Post", "0")
    End Function

End Class
