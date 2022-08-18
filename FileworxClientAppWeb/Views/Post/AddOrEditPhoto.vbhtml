﻿@ModelType Photo

@Code

    ViewData("Title") = "AddOrEditPhoto"


End Code



<h2>EditPost</h2>
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

                //document.getElementById("Image").value = input.files[0].name;
                //alert(document.getElementById("Image").value);
                //<td><input id="Image" name="Image" type="text" value="#" /></td>
            }

        };


    </script>
</head>


<body>
    <div class="container">

        @Using (Html.BeginForm("SavePhoto", "Post", FormMethod.Post, New With {.enctype = "multipart/form-data", .post = Model}))

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
                    <td>Body</td>
                    <td>

                        <textarea id="Body" name="Body">@Model.Body</textarea>

                    </td>
                </tr>


                    <tr>
                        <td>Image</td>
                        <td>

                            <img id="blah" name="ImageViewer" src="@Model.Image" width="300" height="250" />
                            <br />
                            <input type="file" accept="image/*" name="fileName" onchange="readURL(this);" />

                        </td>
                    </tr>

                    <tr hidden>
                        
                        <td><input id="FilePath" name="FilePath" type="text" value="@Model.FilePath" /></td>
                        <td><input id="CreationDate" name="CreationDate" type="text" value="@Model.CreationDate" /></td>
                    </tr>

                <tr>
                    <td><input type="submit" value="Save" class="btn btn-primary  col-sm-6" /></td>
                    <td></td>
                </tr>

            </table>

        End Using



    </div>
</body>