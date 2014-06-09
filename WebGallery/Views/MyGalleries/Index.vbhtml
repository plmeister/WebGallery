@ModelType WebGallery.MyGalleriesIndex

@Code
    ViewData("Title") = "My Galleries"
End Code

<h2>My Galleries</h2>

@Html.ActionLink("Create", "Create")

<ul>
    @For Each g In Model.Galleries
        @<li>@Html.ActionLink(g.Name, "Edit", New With {.id = g.GalleryId})</li>
    Next
</ul>