@ModelType WebGallery.GalleryDisplayViewModel
@Code
    ViewData("Title") = Model.Name
End Code

<h2>@Model.Name</h2>

<div>
    <ul>
        @For Each i In Model.Items
            @<li>@i.Name</li>
        Next
    </ul>
</div>
<p>
    @*@Html.ActionLink("Edit", "Edit", New With {.id = Model.PrimaryKey}) |*@
    @Html.ActionLink("Back to List", "Index")
</p>
