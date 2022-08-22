@ModelType List(Of Post)

@Code
    ViewData("Title") = "Welcome " & ApplicationSettings.currentUserName
End Code



<h2>@ViewData("Title")</h2>
<br />
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

@code

    Dim columnNames = New List(Of String)
    columnNames.Add("Title")
    columnNames.Add("CreationDate")
    columnNames.Add("Description")

    Dim grid = New WebGrid(Model, columnNames)

End Code

<div class="container">

    @grid.GetHtml(columns:=grid.Columns(
                                                     grid.Column("Title"),
                                                     grid.Column("CreationDate"),
                                                     grid.Column("Description"),
                                         grid.Column(format:=@@<div class="container-fluid">
                                    <div class="row" style="justify-content: space-around; display: flex">
                                        <a href="/Post/ViewPost?postIndex=@Model.IndexOf(item.Value)" Class="btn btn-info col-lg-3">View</a>
                                        <a href="/Post/AddOrEditPost?postIndex=@Model.IndexOf(item.Value)" Class="btn btn-warning col-lg-3">Edit</a>
                                        <a href="/Post/DeletePost?postIndex=@Model.IndexOf(item.Value)" Class="btn btn-danger col-lg-4">Delete</a>
                                    </div>
                                </div>                      )
                                  ), tableStyle:="table table-bordered")

</div>