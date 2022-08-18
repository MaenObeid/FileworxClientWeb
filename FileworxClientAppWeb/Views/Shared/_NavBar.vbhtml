<div class="navbar navbar-inverse navbar-fixed-top">
    <div class="container">
        <div class="navbar-header">
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            @Html.ActionLink("Application name", "Index", "Home", New With {.area = ""}, New With {.class = "navbar-brand"})
        </div>
        <div class="navbar-collapse collapse">
            <ul class="nav navbar-nav">
                <li>@Html.ActionLink("Home", "Index", "Home")</li>
                <li>@Html.ActionLink("About", "About", "Home")</li>
                <li>@Html.ActionLink("Contact", "Contact", "Home")</li>
                <li>@Html.ActionLink("Add News", "AddOrEditNews", "Post")</li>
                <li>@Html.ActionLink("Add Photo", "AddOrEditPhoto", "Post")</li>
                <li>@Html.ActionLink("SignIn", "SignIn", "User")</li>
            </ul>
        </div>
    </div>
</div>
