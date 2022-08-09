Public Class Photo
    Inherits Post

    Public Property Image() As String

    Public Sub New(title As String, description As String, body As String, image As String)

        MyBase.New(title, description, body)
        Me.Image = image

    End Sub

    Public Sub New(record As String())

        MyBase.New(record(0), record(1), record(3), CType(record(4), DateTime))
        Me.Image = record(2)

    End Sub

    Public Overrides Function toFileReprisintation() As String

        Return Title & "$$" & Description & "$$" & Image & "$$" & Body & "$$" & CreationDate

    End Function

End Class
