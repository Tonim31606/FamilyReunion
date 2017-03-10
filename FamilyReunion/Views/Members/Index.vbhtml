@ModelType IEnumerable(Of FamilyReunion.Member)
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.FirstName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.LastName)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.FirstName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.LastName)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.MemberId }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.MemberId }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.MemberId })
        </td>
    </tr>
Next

</table>
