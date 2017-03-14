@ModelType  FamilyReunion.ViewModels.MemberDetailsViewModel

@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div class="col-md-6">
    <h4>Member</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Member.FirstName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Member.FirstName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Member.LastName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Member.LastName)
        </dd>

    </dl>
</div>
<div class="col-md-6">
    <h4>Phones:</h4>

    @Html.Partial("PhoneList", New ViewModels.PhoneListViewModel With {.PhoneNumbers =
                                                       If(Model.IsCurrentUser, Model.Member.PhoneNumbers, Model.Member.PhoneNumbers.Where(Function(p) Not p.IsPrivate)),
                                                       .Member = Model.Member, .HidePrivate = Not Model.IsCurrentUser})
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.Member.MemberId}) |
    @Html.ActionLink("Back to List", "Index")
</p>
