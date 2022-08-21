@ModelType News

@Code

    Dim news As News = Model

    ViewData("Title") = "Edit News"

    If Model Is Nothing Then
        news = New News()

        ViewData("Title") = "Add News"

    End If


    'ViewData("Title") = "AddOrEditPost"

    'Dim result = ""
    '
    'If IsPost Then
    '    Dim firstName = Request("FirstName")
    '    Dim lastName = Request("LastName")
    '    Dim email = Request("Email")
    '    Dim userData = firstName & "," + lastName & "," + email + Environment.NewLine
    '    Dim dataFile = Server.MapPath("~/App_Data/data.txt")
    '    File.WriteAllText(dataFile, userData)
    '    result = "Information saved."
    'End If


    'If IsPost Then
    '
    '    If (Request.Files.Count > 0) Then
    '
    '        Dim file = Request.Files(0)
    '        If (file Is Nothing AndAlso file.ContentLength > 0) Then
    '
    '            Dim fileName = Path.GetFileName(file.FileName)
    '            Dim th = Path.Combine(Server.MapPath("~/Content/"), fileName)
    '
    '            file.SaveAs(th)
    '
    '        End If
    '    End If
    'End If
    'Dim post As Post
    'Dim postType As Type
    '
    'If Integer.Parse(ViewData("Post")) >= 0 Then
    '
    '    post = ApplicationSettings.postsMenu(ViewData("Post"))
    '    postType = post.GetType()
    '
    'Else
    '
    '    If ViewData("Type") = GetType(News) Then
    '
    '        post = New News("", "", 0, "")
    '
    '    ElseIf ViewData("Type") = GetType(Photo) Then
    '
    '        post = New Photo("", "", "", "")
    '
    '    End If
    'End If

End Code



<h2>@ViewData("Title")</h2>

<head>

</head>

<body>
    <div class="container">



        @Using (Html.BeginForm("SaveNews", "Post", FormMethod.Post, New With {.enctype = "multipart/form-data"}))

            @<table Class="table table-info table-striped">
                <tr>
                    <td>Title</td>
                    <td><input id="Title" name="Title" type="text" value="@news.Title" required /></td>

                </tr>
                <tr>
                    <td>Description</td>
                    <td><input id="Description" name="Description" type="text" value="@news.Description" required /></td>
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

                        <textarea id="Body" name="Body" required>@news.Body</textarea>

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


