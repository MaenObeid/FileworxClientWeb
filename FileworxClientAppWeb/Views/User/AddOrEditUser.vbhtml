@ModelType User

@Code
    ViewData("Title") = "Edit User"

    Dim user As User = Model

    If Model Is Nothing Then
        user = New User()
        ViewData("Title") = "Add User"
    End If

End Code

<body>

    <h2>@ViewData("Title")</h2>
    <br />

    @If ViewData("Message") IsNot Nothing Then

        @<div Class="alert alert-warning" role="alert">
            @ViewData("Message")
        </div>

    End If

    @If TempData("Message") IsNot Nothing Then

        @<br />
        @<br />

        @<div Class="alert alert-warning" role="alert">
            @TempData("Message")
        </div>

    End If


    <br />
    <br />


    <div class="container">

        @Using (Html.BeginForm("AddOrEditUser", "User", FormMethod.Post, New With {.enctype = "multipart/form-data"}))

            @<table Class="table table-info table-striped">
                <tr>

                    <td>Full Name</td>
                    <td><input id="FullName" name="FullName" type="text" value="@user.FullName" required /></td>

                </tr>

                <tr>

                    <td>Login Name</td>
                    <td><input id="LoginName" name="LoginName" type="text" value="@user.LoginName" required /></td>

                </tr>

                <tr>

                    <td>Password</td>
                    <td><input id="Password" name="Password" type="password" minlength="8" value="@user.Password" required /></td>

                </tr>

                <tr hidden>

                    <td><input id="LastModifier" name="LastModifier" type="text" value="@ApplicationSettings.currentUserName" /></td>
                    <td>@Html.CheckBox("Activity", user.Activity)</td>
                    <td><input id="FilePath" name="FilePath" type="text" value="@user.FilePath" /></td>

                </tr>

                <tr>

                    <td><input type="submit" value="Save" class="btn btn-primary  col-sm-6" /></td>
                    <td></td>

                </tr>

            </table>

        End Using



    </div>
</body>