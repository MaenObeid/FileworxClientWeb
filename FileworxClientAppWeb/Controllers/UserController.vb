Imports System.Web.Mvc

Namespace Controllers
    Public Class UserController
        Inherits Controller

        ' GET: User
        Function Index() As ActionResult
            Return View()
        End Function

        <HttpGet>
        Function SignIn() As ActionResult

            Try

                UserFunctions.LoadUsers()

            Catch ex As Exception
                ViewData("Message") = ex.Message.ToString()
            End Try

            Return View()
        End Function

        <HttpPost>
        Function SignIn(user As User) As ActionResult

            Try

                If UserFunctions.SignIn(user) Then

                    Return RedirectToAction("Index", "Home")

                End If

                TempData("Message") = "Wrong user name or password"

            Catch ex As Exception
                TempData("Message") = ex.Message.ToString()
            End Try

            Return RedirectToAction("SignIn")
        End Function

        Function Users() As ActionResult

            Return View(ApplicationSettings.usersList)
        End Function

        <HttpGet>
        Function AddUser(userIndex As String) As ActionResult
            If userIndex Is Nothing Then

                Return View()

            End If

            Return View(ApplicationSettings.usersList(userIndex))
        End Function

        <HttpPost>
        Function AddUser(user As User) As ActionResult

            Try

                UserFunctions.AddUser(user)

                TempData("Message") = "User added successfully"

                Return RedirectToAction("Index", "Home")

            Catch ex As Exception

                TempData("Message") = ex.Message.ToString()

            End Try

            Return View()
        End Function


        'Function EditUser(userIndex As String)
        '
        '
        '
        'End Function

        Function ChangeActivity(userIndex As String) As ActionResult

            Try

                UserFunctions.ChangeActivity(userIndex)

            Catch ex As Exception
                TempData("Message") = ex.Message.ToString()
            End Try

            Return RedirectToAction("Users")
        End Function


        Function SignOut() As ActionResult

            ApplicationSettings.currentUserName = Nothing

            Return RedirectToAction("SignIn")
        End Function

    End Class
End Namespace