@ModelType News

@Code

    Dim news As News = Model

    ViewData("Title") = "Edit News"

    If Model Is Nothing Then
        news = New News()

        ViewData("Title") = "Add News"

    End If

End Code




<body>

    <h2>@ViewData("Title")</h2>

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

        @Using (Html.BeginForm("SaveNews", "Post", FormMethod.Post, New With {.enctype = "multipart/form-data"}))

            @<table Class="table table-info table-striped">
                <tr>
                    <td>Title</td>
                    <td><input id="Title" name="Title" type="text" value="@news.Title" maxlength="254" required /></td>

                </tr>
                <tr>
                    <td>Description</td>
                    <td><input id="Description" name="Description" type="text" value="@news.Description" maxlength="254" required /></td>
                </tr>

                <tr>
                    <td>
                        Category
                    </td>

                    <td>
                        <select id="Category" name="Category">
                            <option id="0" value="0"> General</option>
                            <option id="1" value="1"> Sports</option>
                            <option id="2" value="2"> Health</option>
                            <option id="3" value="3"> Politics</option>
                        </select>
                    </td>
                </tr>

                <tr>
                    <td>Body</td>
                    <td>

                        <textarea id="Body" name="Body" maxlength="9999" required>@news.Body</textarea>

                    </td>
                </tr>

                <tr hidden>
                    <td><input id="FilePath" name="FilePath" type="text" value="@news.FilePath" /></td>
                    <td><input id="CreationDate" name="CreationDate" type="text" value="@news.CreationDate" /></td>
                </tr>

                <tr>
                    <td><input type="submit" value="Save" class="btn btn-primary  col-sm-6" /></td>
                    <td></td>
                </tr>

            </table>

        End Using



    </div>
</body>

<script>

    var CategorySettings = @Html.Raw(Json.Encode(news.Category));

    document.getElementById(CategorySettings).setAttribute('selected', 'selected');

</script>


