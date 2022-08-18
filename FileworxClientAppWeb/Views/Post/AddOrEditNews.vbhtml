@ModelType News

@Code

    ViewData("Title") = "AddOrEditPost"

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



<h2>EditPost</h2>
<head>
    <script>

       
        /*Imagee.onchange = evt => {
            const [file] = Imagee.files
            if (file) {
                blah.src = file
                blah.alt = file
            }
        }*/
        function readURL(input) {
            if (input.files && input.files[0]) {

                alert(input.files[0].name);

                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#blah')
                        .attr('src', e.target.result)
                        .width(150)
                        .height(200);
                };

                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
</head>


<body>
    <div class="container">

        @Using (Html.BeginForm("SaveNews", "Post", FormMethod.Post, New With {.enctype = "multipart/form-data"}))

            @<table Class="table table-info table-striped">
                <tr>
                    <td>Title</td>
                    <td><input id="Title" name="Title" type="text" value="@Model.Title" /></td>

                </tr>
                <tr>
                    <td>Description</td>
                    <td><input id="Description" name="Description" type="text" value="@Model.Description" /></td>
                </tr>

                    <tr>
                        <td>
                            Category
                        </td>

                        <td>
                            <select id="Category" name="Category">
                                <option value=0> General</option>
                                <option value=1> Sports</option>
                                <option value=2> Health</option>
                                <option value=3> Politics</option>
                            </select>
                        </td>
                    </tr>

                <tr>
                    <td>Body</td>
                    <td>

                        <textarea id="Body" name="Body">@Model.Body</textarea>

                    </td>
                </tr>

             <tr hidden>
                 <td><input id="FilePath" name="FilePath" type="text" value="@Model.FilePath" /></td>
                 <td><input id="CreationDate" name="CreationDate" type="text" value="@Model.CreationDate" /></td>
             </tr>

                <tr>
                    <td><input type="submit" value="Save" class="btn btn-primary  col-sm-6"/></td>
                    <td></td>
                </tr>

            </table>

        End Using



    </div>
</body>
