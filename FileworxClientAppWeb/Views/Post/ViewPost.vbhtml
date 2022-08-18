
@Code
    ViewData("Title") = "ViewPost"

    Dim post As Post = ViewData("Post")

    Dim postType = post.GetType()
End Code

<script>
    function PickImage(image) {

        return URL.createObjectURL(image);
    }
</script>


<body>

    <h2>@postType.ToString</h2>


    <div Class="container">
        <Table Class="table table-info table-striped">
            <tr>
                <th scope="row">
                    Title
                </th>

                <td>
                    @post.Title
                </td>
            </tr>

            <tr>
                <th scope="row">
                    Creation Date
                </th>

                <td>
                    @post.CreationDate
                </td>
            </tr>

            @If postType = GetType(News) Then
                @<tr>
                    <th scope="row">
                        Category
                    </th>

                    <td>
                        @CType(post, News).Category.ToString
                    </td>
                </tr>
            End If

            <tr>
                <th scope="row">
                    Body
                </th>

                <td>
                    @post.Body
                </td>
            </tr>

            @If postType = GetType(Photo) Then

                Dim img As String = CType(post, Photo).Image
                @<tr>
                    <th scope="row">
                        Image
                    </th>

                    <td>
                        
                        <img src="@Url.Content(img)"/>
                    </td>
                </tr>
            End If
        </Table>
    </div>


</body>