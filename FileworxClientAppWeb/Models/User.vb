Public Class User

    Public Property FullName() As String
    Public Property LoginName() As String
    Public Property Password() As String
    Public Property LastModifier() As String
    Public Property FilePath() As String
    Public Property Activity() As Boolean


    Public Sub New(fullName As String, loginName As String, password As String, lastModifier As String, Optional filePath As String = "", Optional activity As Boolean = True)

        ' checking the limits before creating the object
        If fullName.Length < 255 AndAlso loginName.Length < 255 AndAlso password.Length < 255 Then

            With Me

                .FullName = fullName
                .LoginName = loginName
                .Password = password
                .LastModifier = lastModifier
                .Activity = activity

                If String.IsNullOrWhiteSpace(filePath) Then

                    .FilePath = ApplicationSettings.usersDirectory & "\" & Guid.NewGuid().ToString() & ".txt"

                Else

                    .FilePath = filePath

                End If

            End With

        Else
            Throw New Exception("Exception -> Some fields exceeded the limit")
        End If

    End Sub

    Public Sub New(record As String(), filePath As String)

        With Me

            .FullName = record(0)
            .LoginName = record(1)
            .Password = record(2)
            .LastModifier = record(3)
            .Activity = record(4)
            .FilePath = filePath

        End With

    End Sub

    Public Function toFileReprisintation() As String

        Return FullName & ApplicationSettings.separator & LoginName & ApplicationSettings.separator & Password & ApplicationSettings.separator & LastModifier & ApplicationSettings.separator & Activity

    End Function

End Class
