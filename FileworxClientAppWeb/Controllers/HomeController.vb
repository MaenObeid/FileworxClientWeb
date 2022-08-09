Imports System.IO

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Public Shared streamWriter As StreamWriter
    Public Shared fileStreamWriter As FileStream
    Public Shared streamReader As StreamReader
    Public Shared fileStreamReader As FileStream

    Shared currentDir As String = AppDomain.CurrentDomain.BaseDirectory.ToString.Split("FileworxClientAppWeb")(0)
    Public Shared usersDirectory As String = currentDir & "FileworxClientAppWeb\Users\"
    Public Shared newsDirectory As String = currentDir & "FileworxClientAppWeb\News\"
    Public Shared photosDirectory As String = currentDir & "FileworxClientAppWeb\Photos\"
    Dim files As ArrayList
    Dim records As New List(Of Post)

    Function Index() As ActionResult
        Try

            files = New ArrayList(Directory.GetFiles(newsDirectory))

            For Each photo In Directory.GetFiles(photosDirectory)

                files.Add(photo)

            Next

            For Each _file In files

                fileStreamReader = New FileStream(_file, FileMode.Open, FileAccess.Read)
                streamReader = New StreamReader(fileStreamReader)

                Dim record = streamReader.ReadLine().Split({"$$"}, System.StringSplitOptions.RemoveEmptyEntries)

                If record(2).Contains(currentDir) Then

                    records.Add(New Photo(record))

                Else

                    records.Add(New News(record))

                End If

                streamReader.Close()

            Next

        Catch ex As Exception
            'MessageBox.Show(ex.Message.ToString)

        End Try

        Return View(records)

    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function

    Function Delete(i As String) As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function

End Class
