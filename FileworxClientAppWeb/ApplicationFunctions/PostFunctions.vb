Imports System.IO

Public Class PostFunctions


    Public Shared Sub LoadPosts()

        If ApplicationSettings.postsMenu.Count <> 0 Then

            Return

        End If

        Dim files() As String = {}

        Try
            Dim newsDirectory = Path.Combine(HttpContext.Current.Server.MapPath(ApplicationSettings.lambda), ApplicationSettings.newsDirectory)

            If Directory.Exists(newsDirectory) Then

                files = Directory.GetFiles(newsDirectory)

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

            Dim photosDirectory = Path.Combine(HttpContext.Current.Server.MapPath(ApplicationSettings.lambda), ApplicationSettings.photosDirectory)

            If Directory.Exists(photosDirectory) Then

                files = Directory.GetFiles(photosDirectory)

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

            Throw ex

        End Try

    End Sub




    Public Shared Sub SavePost(post As Post)

        If (post.GetType = GetType(News)) Then

            If ApplicationSettings.postsMenu.Contains(post) Then


                Dim i = post.FilePath

            End If

            Dim newsDirectory = Path.Combine(HttpContext.Current.Server.MapPath(ApplicationSettings.lambda), ApplicationSettings.newsDirectory)


            If Not Directory.Exists(newsDirectory) Then

                Directory.CreateDirectory(newsDirectory)

            End If

            'Dim fileStreamWriter = New FileStream(Path.Combine(Server.MapPath("~/News/"), "4e21037c-1141-4f8a-9574-a63cc3a5aeda.txt"), FileMode.OpenOrCreate, FileAccess.Write)
            '
            'Using streamWriter As New StreamWriter(fileStreamWriter)
            '
            '    streamWriter.WriteLine(post.toFileReprisintation())
            '
            '    If Not ApplicationSettings.postsMenu.Contains(post) Then
            '
            '        ApplicationSettings.postsMenu.Add(post)
            '
            '    End If
            '
            'End Using

            'Dim filePath As String = Path.Combine(Server.MapPath("~"), post.FilePath)
            '
            'IO.File.WriteAllText(filePath, post.toFileReprisintation())
            '
            'For Each row As Post In ApplicationSettings.postsMenu
            '
            '    'removes the object if it exists (to replace it with new object)
            '    If row.FilePath = post.FilePath Then
            '        ApplicationSettings.postsMenu.Remove(row)
            '        Exit For
            '    End If
            '
            'Next
            '
            'ApplicationSettings.postsMenu.Add(post)

        ElseIf (post.GetType = GetType(Photo)) Then

            Dim photosDirectory = Path.Combine(HttpContext.Current.Server.MapPath(ApplicationSettings.lambda), ApplicationSettings.photosDirectory)


            If Not Directory.Exists(photosDirectory) Then

                Directory.CreateDirectory(photosDirectory)

            End If

            If (HttpContext.Current.Request.Files.Count > 0) Then

                Dim image = HttpContext.Current.Request.Files(0)

                If (image IsNot Nothing AndAlso image.ContentLength > 0) Then

                    Dim imageName = Path.GetFileName(image.FileName)
                    Dim imagesDirectory = Path.Combine(HttpContext.Current.Server.MapPath(ApplicationSettings.lambda), ApplicationSettings.imagesDirectory)

                    Dim imagePath = Path.Combine(imagesDirectory, imageName)

                    image.SaveAs(imagePath)

                    CType(post, Photo).Image = Path.Combine(Path.DirectorySeparatorChar, ApplicationSettings.imagesDirectory, imageName)

                End If

            End If

        End If

        Dim filePath As String = Path.Combine(HttpContext.Current.Server.MapPath(ApplicationSettings.lambda), post.FilePath)

        IO.File.WriteAllText(filePath, post.toFileReprisintation())

        For Each row As Post In ApplicationSettings.postsMenu

            'removes the object if it exists (to replace it with new object)
            If row.FilePath = post.FilePath Then
                ApplicationSettings.postsMenu.Remove(row)
                Exit For
            End If

        Next

        ApplicationSettings.postsMenu.Add(post)


        'Try
        '    If File.ContentLength > 0 Then
        '        Dim _FileName As String = Path.GetFileName(File.FileName)
        '        Dim _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName)
        '        File.SaveAs(_path)
        '    End If
        '    ViewBag.Message = "File Uploaded Successfully!!"
        '    Return View()
        'Catch
        '    ViewBag.Message = "File upload failed!!"
        '    Return View()
        'End Try

    End Sub

    Public Shared Sub DeletePost(postIndex As Integer)

        Dim post As Post = ApplicationSettings.postsMenu(postIndex)

        If File.Exists(post.FilePath) Then

            File.Delete(post.FilePath)

            If post.GetType = GetType(Photo) Then

                File.Delete(HttpContext.Current.Server.MapPath(CType(post, Photo).Image))

            End If
        End If

        ApplicationSettings.postsMenu.RemoveAt(postIndex)

    End Sub


End Class
