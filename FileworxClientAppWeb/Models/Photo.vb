Imports System.IO

Public Class Photo
    Inherits Post

    Public Property Image() As String


    Public Sub New()
        MyBase.New()
    End Sub


    Public Sub New(title As String, description As String, body As String, image As String, Optional filePath As String = "")

        MyBase.New(title, description, body, filePath)
        Me.Image = image

        If String.IsNullOrWhiteSpace(filePath) Then

            Me.FilePath = Path.Combine(ApplicationSettings.photosDirectory, Me.FilePath)

        End If

    End Sub

    Public Sub New(record As String(), filePath As String)

        MyBase.New(record(0), record(1), record(3), filePath, CType(record(4), DateTime))
        Me.Image = record(2)

    End Sub

    Public Overrides Function toFileReprisintation() As String

        Return Title & ApplicationSettings.separator & Description & ApplicationSettings.separator & Image & ApplicationSettings.separator & Body & ApplicationSettings.separator & CreationDate

    End Function

End Class
