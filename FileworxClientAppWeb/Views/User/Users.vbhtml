@ModelType List(Of User)

@Code
    ViewData("Title") = "Users"
End Code

<h2>@ViewData("Title")</h2>

<div class="container">

    <table id="assets-data-table" class="table table-striped table-bordered">
        <thead>
            <tr>

                <th>Name</th>
                <th>Login Name</th>
                <th>Last Modifier</th>
                <th>Activity</th>

            </tr>
        </thead>
        <tbody>
            @For Each user As User In Model

                @<tr>

                    <td>@user.FullName</td>
                    <td>@user.LoginName</td>
                    <td>@user.LastModifier</td>
                    <td>
                        <div class="row" style="justify-content: space-around; display: flex">
                            @If user.Activity Then

                                @<a href="/User/ChangeActivity?userIndex=@Model.IndexOf(user)" Class="btn btn-danger col-sm-5">Disable</a>

                            Else

                                @<a href="/User/ChangeActivity?userIndex=@Model.IndexOf(user)" Class="btn btn-success col-sm-5">Enable</a>

                            End If

                            <a href="/User/AddUser?userIndex=@Model.IndexOf(user)" Class="btn btn-warning col-sm-5">Edit</a>
                        </div>
                    </td>


                </tr>

            Next

        </tbody>
    </table>

</div>