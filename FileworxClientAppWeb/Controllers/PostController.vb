Imports System.IO

Namespace Controllers
    Public Class PostController
        Inherits Controller


        Function ViewPost(postIndex As String) As ActionResult

            If String.IsNullOrWhiteSpace(postIndex) Then

                Return RedirectToAction("Index", "Home")

            End If

            Return View(ApplicationSettings.postsMenu(postIndex))

        End Function

        Function AddOrEditPost(postIndex As String) As ActionResult

            If ApplicationSettings.postsMenu(postIndex).GetType = GetType(News) Then

                Return RedirectToAction("AddOrEditNews", New With {.postIndex = postIndex})

            ElseIf ApplicationSettings.postsMenu(postIndex).GetType = GetType(Photo) Then

                Return RedirectToAction("AddOrEditPhoto", New With {.postIndex = postIndex})

            End If

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
            Try

                PostFunctions.SavePost(post)

                TempData("Message") = "News saved successfully"

            Catch ex As Exception
                TempData("Message") = ex.Message.ToString()
            End Try

            Return RedirectToAction("Index", "Home")
        End Function

        Function SavePhoto(post As Photo) As ActionResult

            Try

                PostFunctions.SavePost(post)

                TempData("Message") = "Photo saved successfully"

            Catch ex As Exception
                TempData("Message") = ex.Message.ToString()
            End Try

            Return RedirectToAction("Index", "Home")
        End Function

        Function DeletePost(postIndex As String) As ActionResult

            Try

                PostFunctions.DeletePost(postIndex)

                TempData("Message") = "Post deleted successfully"

            Catch ex As Exception
                TempData("Message") = ex.Message.ToString()
            End Try

            Return RedirectToAction("Index", "Home")

        End Function


    End Class
End Namespace