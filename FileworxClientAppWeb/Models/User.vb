Public Class User

    Public Property FullName() As String
    Public Property LoginName() As String
    Public Property Password() As String
    Public Property LastModifier() As String
    Public Property Activity() As Boolean

    Public Sub New(fullName As String, loginName As String, password As String, lastModifier As String, Optional activity As Boolean = True)

        ' checking the limits before creating the object
        If fullName.Length < 255 AndAlso loginName.Length < 255 AndAlso password.Length < 255 Then

            With Me

                .FullName = fullName
                .LoginName = loginName
                .Password = password
                .LastModifier = lastModifier
                .Activity = activity

            End With

        Else
            Throw New Exception("Exception -> Some fields exceeded the limit")
        End If

    End Sub

    Public Function toFileReprisintation() As String

        Return FullName & "$$" & LoginName & "$$" & Password & "$$" & LastModifier & "$$" & Activity

    End Function

End Class
