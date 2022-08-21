
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

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."
        Return View()
    End Function

    Function Contact(s As String) As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function

    Function Delete(i As String) As ActionResult
        'ViewData("Message") = "Your contact page."


        Return RedirectToAction("ViewPost", "Post", "0")
    End Function

End Class
