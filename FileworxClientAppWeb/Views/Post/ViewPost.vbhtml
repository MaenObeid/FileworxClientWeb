@ModelType Post
@Code
    ViewData("Title") = Model.Title

    Dim postType = Model.GetType()

End Code

<script>
    function PickImage(image) {

        return URL.createObjectURL(image);
    }
</script>


<body>

    <h2>@ViewData("Title")</h2>


    <div Class="container">
        <Table Class="table table-info table-striped">
            <tr>
                <th scope="row">
                    Title
                </th>

                <td>
                    @Model.Title
                </td>
            </tr>

            <tr>
                <th scope="row">
                    Creation Date
                </th>

                <td>
                    @Model.CreationDate
                </td>
            </tr>

            @If postType = GetType(News) Then
                @<tr>
                    <th scope="row">
                        Category
                    </th>

                    <td>
                        @CType(Model, News).Category.ToString
                    </td>
                </tr>
            End If

            <tr>
                <th scope="row">
                    Body
                </th>

                <td>
                    @Model.Body
                </td>
            </tr>

            @If postType = GetType(Photo) Then

                Dim img As String = CType(Model, Photo).Image

                @<tr>
                    <th scope="row">
                        Image
                    </th>

                    <td>

                        <img src="@Url.Content(img)" />
                    </td>
                </tr>
            End If
        </Table>
    </div>


</body>