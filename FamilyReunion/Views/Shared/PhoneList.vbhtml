@ModelType ViewModels.PhoneListViewModel

@If Model.PhoneNumbers.Count = 0 Then
    @<div class="alert alert-warning">No phone numbers found.</div>
Else
    @<table Class="table">
        <tr>
            <th>
                Phone Number
            </th>
            <th>
                Phone Type
            </th>
        </tr>

        @For Each item In Model.PhoneNumbers
            @<tr>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Phone)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.PhoneType)
                </td>


            </tr>
        Next

    </table>


End If
