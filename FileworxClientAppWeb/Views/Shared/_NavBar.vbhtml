<div class="navbar navbar-inverse navbar-fixed-top">
    <div class="container">
        <div class="navbar-header">
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <span class="navbar-brand">FileworxClient</span>
        </div>
        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            <ul class="nav navbar-nav">
                @If String.IsNullOrWhiteSpace(ApplicationSettings.currentUserName) Then

                    @<li>@Html.ActionLink("SignIn", "SignIn", "User")</li>

                Else

                    @<li>@Html.ActionLink("Home", "Index", "Home")</li>
                    @<li>@Html.ActionLink("Users", "Users", "User")</li>

                    @<li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Add<span class="caret"></span></a>
                        <ul class="dropdown-menu">

                            <li>@Html.ActionLink("Add Photo", "AddOrEditPhoto", "Post")</li>
                            <li>@Html.ActionLink("Add News", "AddOrEditNews", "Post")</li>
                            <li>@Html.ActionLink("Add User", "AddOrEditUser", "User")</li>

                        </ul>
                    </li>

                    @<li>@Html.ActionLink("Sign Out", "SignOut", "User")</li>

                End If

            </ul>
    </div>
</div>
</div>
