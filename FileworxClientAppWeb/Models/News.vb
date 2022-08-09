Public Class News
    Inherits Post

    Public Property Category() As Category

    Public Sub New(title As String, description As String, category As Category, body As String)

        MyBase.New(title, description, body)
        Me.Category = category

    End Sub

    Public Sub New(record As String())

        MyBase.New(record(0), record(1), record(3), CType(record(4), DateTime))
        Me.Category = record(2)

    End Sub

    Public Overrides Function toFileReprisintation() As String

        Return Title & "$$" & Description & "$$" & Category & "$$" & Body & "$$" & CreationDate

    End Function

End Class
