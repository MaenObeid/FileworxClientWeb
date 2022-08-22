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
        Try

            If (post.GetType = GetType(News)) Then

                If ApplicationSettings.postsMenu.Contains(post) Then


                    Dim i = post.FilePath

                End If

                Dim newsDirectory = Path.Combine(HttpContext.Current.Server.MapPath(ApplicationSettings.lambda), ApplicationSettings.newsDirectory)


                If Not Directory.Exists(newsDirectory) Then

                    Directory.CreateDirectory(newsDirectory)

                End If

            ElseIf (post.GetType = GetType(Photo)) Then

                Dim photosDirectory = Path.Combine(HttpContext.Current.Server.MapPath(ApplicationSettings.lambda), ApplicationSettings.photosDirectory)
                Dim imagesDirectory = Path.Combine(HttpContext.Current.Server.MapPath(ApplicationSettings.lambda), ApplicationSettings.imagesDirectory)


                If Not Directory.Exists(photosDirectory) Then

                    Directory.CreateDirectory(photosDirectory)

                End If

                If Not Directory.Exists(imagesDirectory) Then

                    Directory.CreateDirectory(imagesDirectory)

                End If

                If (HttpContext.Current.Request.Files.Count > 0) Then

                    Dim image = HttpContext.Current.Request.Files(0)

                    If (image IsNot Nothing AndAlso image.ContentLength > 0) Then

                        Dim imageName = Path.GetFileName(image.FileName)

                        Dim imagePath = Path.Combine(imagesDirectory, imageName)

                        image.SaveAs(imagePath)

                        CType(post, Photo).Image = Path.Combine(Path.DirectorySeparatorChar, ApplicationSettings.imagesDirectory, imageName)

                    End If

                End If

            End If

            Dim filePath As String = Path.Combine(HttpContext.Current.Server.MapPath(ApplicationSettings.lambda), post.FilePath)

            File.WriteAllText(filePath, post.toFileReprisintation())

            For Each row As Post In ApplicationSettings.postsMenu

                'removes the object if it exists (to replace it with new object)
                If row.FilePath = post.FilePath Then

                    If row.GetType = GetType(Photo) Then

                        Dim imagePath As String = HttpContext.Current.Server.MapPath(CType(row, Photo).Image)
                        File.Delete(imagePath)

                    End If

                    ApplicationSettings.postsMenu.Remove(row)
                    Exit For

                End If

            Next

            ApplicationSettings.postsMenu.Add(post)

        Catch ex As Exception

            Throw ex

        End Try

    End Sub


    Public Shared Sub DeletePost(postIndex As Integer)

        Try

            Dim post As Post = ApplicationSettings.postsMenu(postIndex)

            If File.Exists(post.FilePath) Then

                File.Delete(post.FilePath)

                If post.GetType = GetType(Photo) Then

                    Dim imagePath As String = HttpContext.Current.Server.MapPath(CType(post, Photo).Image)
                    File.Delete(imagePath)

                End If
            End If

            ApplicationSettings.postsMenu.RemoveAt(postIndex)

        Catch ex As Exception

            Throw ex

        End Try

    End Sub


End Class
