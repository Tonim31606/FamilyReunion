@ModelType ViewModels.MemberEditViewModel
@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>
<div class="col-md-6">
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-horizontal">
            <h4>Member</h4>
            <hr />
            @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
            @Html.HiddenFor(Function(model) model.Member.MemberId)

            <div class="form-group">
                @Html.LabelFor(Function(model) model.Member.FirstName, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Member.FirstName, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.Member.FirstName, "", New With {.class = "text-danger"})
                </div>
            </div>

            <div class="form-group">
                @Html.LabelFor(Function(model) model.Member.LastName, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Member.LastName, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.Member.LastName, "", New With {.class = "text-danger"})
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <input type="submit" value="Save" class="btn btn-default" />
                </div>
            </div>
        </div>
    End Using
</div>
<div class="col-md-6">
    <h4>Phones:</h4>
    @Html.Partial("PhoneListEdit", New ViewModels.PhoneListViewModel With {.PhoneNumbers = Model.Member.PhoneNumbers, .Member = Model.Member, .HidePrivate = Model.IsCurrentUser})
</div>
<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@Section Scripts 
    @Scripts.Render("~/bundles/jqueryval")
End Section
