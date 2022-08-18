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

        If ApplicationSettings.postsMenu.Count <> 0 Then

            Return View(ApplicationSettings.postsMenu)
        End If

        Dim files() As String = {}

        Try

            If Directory.Exists(Server.MapPath(ApplicationSettings.newsDirectory)) Then

                files = Directory.GetFiles(Server.MapPath(ApplicationSettings.newsDirectory))

            End If

            For Each file As String In files

                Using fileStreamReader As New FileStream(file, FileMode.Open, FileAccess.Read)

                    Using streamReader As New StreamReader(fileStreamReader)

                        Dim record As String() = streamReader.ReadLine().Split({ApplicationSettings.separator}, System.StringSplitOptions.RemoveEmptyEntries)

                        ApplicationSettings.postsMenu.Add(New News(record, file))

                    End Using

                End Using

            Next

            files = {}

            If Directory.Exists(Server.MapPath(ApplicationSettings.photosDirectory)) Then

                files = Directory.GetFiles(Server.MapPath(ApplicationSettings.photosDirectory))

            End If

            For Each file As String In files

                Using fileStreamReader As New FileStream(file, FileMode.Open, FileAccess.Read)

                    Using StreamReader As New StreamReader(fileStreamReader)

                        Dim record As String() = StreamReader.ReadLine().Split({ApplicationSettings.separator}, System.StringSplitOptions.RemoveEmptyEntries)

                        ApplicationSettings.postsMenu.Add(New Photo(record, file))

                    End Using

                End Using

            Next


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
