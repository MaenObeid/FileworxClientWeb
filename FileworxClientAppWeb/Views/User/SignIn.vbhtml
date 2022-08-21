@Code
    ViewData("Title") = "Sign In"
End Code

<h2>SignIn</h2>

<div class="container">


    @If TempData("Message") IsNot Nothing Then

        @<br />
        @<br />

        @<div Class="alert alert-warning" role="alert">
            @TempData("Message")
        </div>

    End If


    <br />
    <br />

    @Using (Html.BeginForm("SignIn", "User", FormMethod.Post, New With {.enctype = "multipart/form-data"}))

        @<table Class="table table-info table-striped">
            <tr>
                <td>User Name</td>
                <td><input id="LoginName" name="LoginName" type="text" required /></td>

            </tr>

            <tr>
                <td>Password</td>
                <td><input id="Password" name="Password" type="text" required /></td>
            </tr>

            <tr>
                <td><input type="submit" value="Sign in" class="btn btn-success" col-sm-6" /></td>
                <td></td>
            </tr>

        </table>

    End Using



</div>