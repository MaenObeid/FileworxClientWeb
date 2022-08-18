Imports System.IO

Public Class News
    Inherits Post

    Public Property Category() As Category

    Public Sub New()
        MyBase.New(ApplicationSettings.newsDirectory)
    End Sub

    Public Sub New(title As String, description As String, category As Category, body As String, Optional filePath As String = "")


        MyBase.New(title, description, body, filePath)
        Me.Category = category

        If String.IsNullOrWhiteSpace(filePath) Then

            Me.FilePath = Path.Combine(ApplicationSettings.newsDirectory, Me.FilePath)

        End If

    End Sub

    Public Sub New(record As String(), filePath As String)

        MyBase.New(record(0), record(1), record(3), filePath, CType(record(4), DateTime))
        Me.Category = record(2)

    End Sub

    Public Overrides Function toFileReprisintation() As String

        Return Title & ApplicationSettings.separator & Description & ApplicationSettings.separator & Category & ApplicationSettings.separator & Body & ApplicationSettings.separator & CreationDate

    End Function

End Class
