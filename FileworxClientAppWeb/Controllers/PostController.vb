Imports System.IO

Namespace Controllers
    Public Class PostController
        Inherits Controller

        ' GET: Post
        Function Index() As ActionResult
            Return View()
        End Function

        Function ViewPost(postIndex As String) As ActionResult

            If postIndex <> String.Empty Then
                ViewData("Post") = ApplicationSettings.postsMenu(postIndex)

            End If

            Return View()

        End Function

        Function AddOrEditPost(postIndex As String) As ActionResult

            If ApplicationSettings.postsMenu(postIndex).GetType = GetType(News) Then

                Return RedirectToAction("AddOrEditNews", New With {.postIndex = postIndex})

            ElseIf ApplicationSettings.postsMenu(postIndex).GetType = GetType(Photo) Then

                Return RedirectToAction("AddOrEditPhoto", New With {.postIndex = postIndex})

            End If

            'ViewData("Type") = GetType(News)


            Return RedirectToAction("Index", "Home")
        End Function



        Function AddOrEditNews(postIndex As String) As ActionResult

            If postIndex Is Nothing Then

                Return View()

            End If

            Return View(ApplicationSettings.postsMenu(postIndex))
        End Function



        Function AddOrEditPhoto(postIndex As String) As ActionResult

            If postIndex Is Nothing Then

                Return View()

            End If

            Return View(ApplicationSettings.postsMenu(postIndex))
        End Function


        Function SaveNews(post As News) As ActionResult

            ApplicationFunctions.SavePost(post)

            Return RedirectToAction("Index", "Home")
        End Function

        Function SavePhoto(post As Photo) As ActionResult

            ApplicationFunctions.SavePost(post)

            Return RedirectToAction("Index", "Home")
        End Function

        Function DeletePost(postIndex As String) As ActionResult

            ApplicationFunctions.DeletePost(postIndex)

            Return RedirectToAction("Index", "Home")

        End Function


    End Class
End Namespace