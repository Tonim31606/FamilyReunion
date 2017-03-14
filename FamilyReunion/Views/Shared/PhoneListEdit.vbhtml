@ModelType ViewModels.PhoneListViewModel

<p>
    @Html.ActionLink("Create New", "Create", "PhoneNumbers", New With {.MemberID = Model.Member.MemberId}, Nothing)
</p>

@If Model.PhoneNumbers.Count = 0 Then
    @<div>No phone numbers found.</div>
Else
    @<Table Class="table">
        <tr>
            <th>
                Phone Number
            </th>
            <th>
               Phone Type
            </th>
            <th></th>
        </tr>

        @For Each item In Model.PhoneNumbers
            @<tr>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Phone)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.PhoneType)
                </td>

                <td>
                    @Html.ActionLink("Edit", "Edit", "PhoneNumbers", New With {.id = item.PhoneID}, Nothing) |
                    @Html.ActionLink("Details", "Details", "PhoneNumbers", New With {.id = item.PhoneID}, Nothing) |
                    @Html.ActionLink("Delete", "Delete", "PhoneNumbers", New With {.id = item.PhoneID}, Nothing)
                </td>
            </tr>
        Next

    </Table>
End If