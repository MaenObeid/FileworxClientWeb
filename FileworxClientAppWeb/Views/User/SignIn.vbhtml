@Code
    ViewData("Title") = "SignIn"
End Code

<h2>SignIn</h2>

<div class="container">



    @Using (Html.BeginForm("CheckUser", "User", FormMethod.Post, New With {.enctype = "multipart/form-data"}))

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