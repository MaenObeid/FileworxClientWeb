@ModelType Photo

@Code

    ViewData("Title") = "Edit Photo"


    Dim photo As Photo = Model

    If Model Is Nothing Then
        photo = New Photo()
        ViewData("Title") = "Add Photo"
    End If

End Code

<head>
    <script>

        function readURL(input) {
            //alert(Myelement.value);

            if (input.files && input.files[0]) {

                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#blah')
                        .attr('src', e.target.result)
                        .width(300)
                        .height(250);

                    $('#Image').attr('value', e.target.result)
                };

                reader.readAsDataURL(input.files[0]);

            }

        };

    </script>
</head>




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

        @Using (Html.BeginForm("SavePhoto", "Post", FormMethod.Post, New With {.enctype = "multipart/form-data", .post = Model}))

            @<table Class="table table-info table-striped">
                <tr>
                    <td>Title</td>
                    <td><input id="Title" name="Title" type="text" value="@photo.Title" maxlength="254" required /></td>

                </tr>
                <tr>
                    <td>Description</td>
                    <td><input id="Description" name="Description" type="text" value="@photo.Description" maxlength="254" required /></td>
                </tr>

                <tr>
                    <td>Body</td>
                    <td>

                        <textarea id="Body" name="Body" maxlength="9999" required>@photo.Body</textarea>

                    </td>
                </tr>


                <tr>
                    <td>Image</td>
                    <td>

                        <img id="blah" name="ImageViewer" src="@photo.Image" width="300" height="250" />
                        <br />
                        <input type="file" accept="image/*" name="fileName" onchange="readURL(this);" />

                    </td>
                </tr>

                <tr hidden>

                    <td><input id="Image" name="Image" type="text" value="@photo.Image" /></td>
                    <td><input id="FilePath" name="FilePath" type="text" value="@photo.FilePath" /></td>
                    <td><input id="CreationDate" name="CreationDate" type="text" value="@photo.CreationDate" /></td>
                </tr>

                <tr>
                    <td><input type="submit" value="Save" class="btn btn-primary  col-sm-6" /></td>
                    <td></td>
                </tr>

            </table>

        End Using

    </div>
</body>
