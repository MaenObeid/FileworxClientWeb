'Abstract class

Imports System.IO

Public MustInherit Class Post
    Public Property Title() As String
    Public Property Description() As String
    Public Property Body() As String
    Public Property CreationDate() As DateTime
    Public Property FilePath() As String


    Public Sub New(directory As String)

        Me.FilePath = Path.Combine(directory, Guid.NewGuid().ToString() & ".txt")
        CreationDate = DateTime.Now

    End Sub


    Public Sub New(title As String, description As String, body As String, filePath As String, Optional creationDate As DateTime = Nothing)

        ' checking the limits before creating the object
        If title.Length < 255 AndAlso description.Length < 255 AndAlso body.Length < 10000 Then

            With Me

                .Title = title
                .Description = description
                .Body = body

                If creationDate = Nothing Then

                    .CreationDate = DateTime.Now
                Else

                    .CreationDate = creationDate

                End If

                If String.IsNullOrWhiteSpace(filePath) Then

                    .FilePath = Guid.NewGuid().ToString() & ".txt"

                Else

                    .FilePath = filePath

                End If

            End With

        Else
            Throw New Exception("Exception -> Some fields exceeded the limit")
        End If


    End Sub

    Public MustOverride Function toFileReprisintation() As String

End Class
