Imports System.IO

Public Class UserFunctions


    Public Shared Sub LoadUsers()

        If ApplicationSettings.usersList.Count <> 0 Then

            Return

        End If

        Try
            Dim usersPath As String = Path.Combine(HttpContext.Current.Server.MapPath(ApplicationSettings.lambda), ApplicationSettings.usersDirectory)
            Dim files() As String = Directory.GetFiles(usersPath)

            For Each file As String In files

                Using fileStreamReader As New FileStream(file, FileMode.Open, FileAccess.Read)

                    Using streamReader = New StreamReader(fileStreamReader)

                        Dim record() As String = streamReader.ReadLine().Split({ApplicationSettings.separator}, System.StringSplitOptions.RemoveEmptyEntries)

                        'creating new user object and save it in usersList
                        ApplicationSettings.usersList.Add(New User(record, file))

                    End Using

                End Using

            Next

        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Public Shared Function SignIn(user As User) As Boolean

        Dim UserExists As Boolean = False

        Try

            For Each registeredUser As User In ApplicationSettings.usersList

                With registeredUser

                    If .LoginName = user.LoginName AndAlso .Password = user.Password AndAlso .Activity Then

                        UserExists = True
                        ApplicationSettings.currentUserName = .FullName
                        Exit For

                    End If

                End With

            Next

        Catch ex As Exception
            Throw ex
        End Try

        Return UserExists

    End Function


    Public Shared Sub AddUser(user As User)

        For Each account As User In ApplicationSettings.usersList

            If account.LoginName = user.LoginName Then

                Throw New Exception("Exception -> Login Name already exists")

            End If

        Next

        Try

            Dim fileStreamWriter = New FileStream(user.FilePath, FileMode.OpenOrCreate, FileAccess.Write)

            Using streamWriter As New StreamWriter(fileStreamWriter)

                streamWriter.WriteLine(user.toFileReprisintation())

            End Using

            For Each row As User In ApplicationSettings.usersList

                'removes the object if it exists (to replace it with new object)
                If row.FilePath = user.FilePath Then
                    ApplicationSettings.usersList.Remove(row)
                    Exit For
                End If

            Next

            ApplicationSettings.usersList.Add(user)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Public Shared Sub ChangeActivity(userIndex As Integer)

        Try

            Dim user As User = ApplicationSettings.usersList(userIndex)

            user.LastModifier = ApplicationSettings.currentUserName
            user.Activity = Not user.Activity

            Using fileStreamWriter As New FileStream(User.FilePath, FileMode.Open, FileAccess.Write)

                Using streamWriter As New StreamWriter(fileStreamWriter)

                    streamWriter.WriteLine(User.toFileReprisintation())

                End Using

            End Using

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

End Class
