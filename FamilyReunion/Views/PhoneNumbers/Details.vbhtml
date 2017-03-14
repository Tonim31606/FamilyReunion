@ModelType FamilyReunion.PhoneNumber
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>PhoneNumber</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Phone)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Phone)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PhoneType)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PhoneType)
        </dd>

        <dt>
           @Html.DisplayNameFor(Function(model) model.Member.Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Member.Name)
            
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.IsPrivate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.IsPrivate)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.PhoneID}) |
    @Html.ActionLink("Back to List", "Index")
</p>
