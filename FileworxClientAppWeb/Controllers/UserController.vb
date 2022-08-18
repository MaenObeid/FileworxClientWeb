Imports System.Web.Mvc

Namespace Controllers
    Public Class UserController
        Inherits Controller

        ' GET: User
        Function Index() As ActionResult
            Return View()
        End Function

        Function SignIn() As ActionResult

            Try

                UserFunctions.LoadUsers()

            Catch ex As Exception
                ViewData("Message") = ex.Message.ToString()
            End Try

            Return View()
        End Function

        Function CheckUser(user As User) As ActionResult

            Try

                If UserFunctions.CheckUser(user) Then

                    Return RedirectToAction("Index", "Home")

                End If

            Catch ex As Exception
                ViewData("Message") = ex.Message.ToString()
            End Try

            Return View()
        End Function

    End Class
End Namespace