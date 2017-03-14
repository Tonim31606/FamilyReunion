@ModelType IEnumerable(Of FamilyReunion.PhoneNumber)
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
            @Html.DisplayNameFor(Function(model) model.Phone)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.PhoneType)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.MemberID)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.IsPrivate)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Phone)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.PhoneType)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.MemberID)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.IsPrivate)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.PhoneID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.PhoneID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.PhoneID })
        </td>
    </tr>
Next

</table>
