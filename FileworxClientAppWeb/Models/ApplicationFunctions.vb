Imports System.IO

Public Class ApplicationFunctions


    Public Shared Sub SavePost(post As Post)

        If (post.GetType = GetType(News)) Then

            If Not Directory.Exists(Path.Combine(HttpContext.Current.Server.MapPath("~"), ApplicationSettings.newsDirectory)) Then

                Directory.CreateDirectory(Path.Combine(HttpContext.Current.Server.MapPath("~"), ApplicationSettings.newsDirectory))

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

            If Not Directory.Exists(Path.Combine(HttpContext.Current.Server.MapPath("~"), ApplicationSettings.photosDirectory)) Then

                Directory.CreateDirectory(Path.Combine(HttpContext.Current.Server.MapPath("~"), ApplicationSettings.photosDirectory))

            End If

            If (HttpContext.Current.Request.Files.Count > 0) Then

                Dim image = HttpContext.Current.Request.Files(0)

                If (image IsNot Nothing AndAlso image.ContentLength > 0) Then

                    Dim imageName = Path.GetFileName(image.FileName)
                    Dim imagePath = Path.Combine(HttpContext.Current.Server.MapPath("~"), ApplicationSettings.imagesDirectory, imageName)

                    image.SaveAs(imagePath)

                    CType(post, Photo).Image = Path.Combine(Path.DirectorySeparatorChar, ApplicationSettings.imagesDirectory, imageName)

                End If

            End If

        End If

        Dim filePath As String = Path.Combine(HttpContext.Current.Server.MapPath("~"), post.FilePath)

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

End Class
