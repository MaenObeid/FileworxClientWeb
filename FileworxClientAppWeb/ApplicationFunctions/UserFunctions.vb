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

    Public Shared Function CheckUser(user As User) As Boolean

        Dim UserExists As Boolean = False

        Try

            For Each registeredUser As User In ApplicationSettings.usersList

                With user

                    If .LoginName = registeredUser.LoginName AndAlso .Password = registeredUser.Password AndAlso .Activity Then

                        UserExists = True
                        ApplicationSettings.currentUserName = registeredUser.FullName
                        Exit For

                    End If

                End With

            Next

        Catch ex As Exception
            Throw ex
        End Try

        Return UserExists

    End Function

End Class
