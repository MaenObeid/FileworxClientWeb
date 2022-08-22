
Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult

        Try

            PostFunctions.LoadPosts()

        Catch ex As Exception
            ViewData("Message") = ex.Message.ToString()
        End Try


        Return View(ApplicationSettings.postsMenu)

    End Function

End Class
