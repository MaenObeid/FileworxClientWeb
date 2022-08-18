@ModelType List(Of Post)

@Code
    ViewData("Title") = "Home Page"
End Code

<div class="jumbotron">
    <h1>ASP.NET</h1>
    <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS and JavaScript.</p>
    <p><a href="https://asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
</div>

<div class="row">
    <div class="col-md-4">
        <h2>Getting started</h2>
        <p>
            ASP.NET MVC gives you a powerful, patterns-based way to build dynamic websites that
            enables a clean separation of concerns and gives you full control over markup
            for enjoyable, agile development.
        </p>
        <p><a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301865">Learn more &raquo;</a></p>
    </div>
    <div class="col-md-4">
        <h2>Get more libraries</h2>
        <p>NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.</p>
        <p><a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301866">Learn more &raquo;</a></p>
    </div>
    <div class="col-md-4">
        <h2>Web Hosting</h2>
        <p>You can easily find a web hosting company that offers the right mix of features and price for your applications.</p>
        <p><a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301867">Learn more &raquo;</a></p>
    </div>
</div>

<br />
<br />
<p>@ViewData("Message")</p>
<br />
<br />

@code

    Dim cn = New List(Of String)
    cn.Add("Title")
    cn.Add("CreationDate")
    cn.Add("Description")

    Dim grid = New WebGrid(Model, cn)

End Code

<div class="container">

    @grid.GetHtml(columns:=grid.Columns(
                                                                        grid.Column("Title"),
                                                                        grid.Column("CreationDate"),
                                                                        grid.Column("Description"),
                                                            grid.Column(format:=@@<div class="container-fluid">
                                                                    <div class="row" style="justify-content: space-around; display: flex">
                                                                        <a href="/Post/ViewPost?postIndex=@ApplicationSettings.postsMenu.IndexOf(item.Value)" Class="btn btn-info col-lg-3">View</a>
                                                                        <a href="/Post/AddOrEditPost?postIndex=@ApplicationSettings.postsMenu.IndexOf(item.Value)" Class="btn btn-warning col-lg-3">Edit</a>
                                                                        <a href="/Home/Delete" Class="btn btn-danger col-lg-4">Delete</a>
                                                                    </div>
                                                                </div>                              )
                                              ), tableStyle:="table table-bordered")

</div>