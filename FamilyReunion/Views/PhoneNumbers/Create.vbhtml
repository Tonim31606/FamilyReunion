@ModelType FamilyReunion.PhoneNumber
@Code
    ViewData("Title") = "Create"
End Code

<h2>Create</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @Html.HiddenFor(Function(p) p.Member.MemberId)

    @<div class="form-horizontal">
        <h4>PhoneNumber</h4>
        <hr />


        @if TempData.ContainsKey("Created") Then
            If TempData.Item("Created") = True Then
                @<div id="CreatedStatus" class="alert alert-success">
                    Phone Number was created.
                </div>
            Else
                @<div id="CreatedStatus" class="alert alert-warning">
                    Phone Number was not created.
                    <p>
                        @TempData.Item("ErrMsg")
                    </p>
                </div>
            End If
        End If


        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Phone, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Phone, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Phone, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.PhoneType, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.PhoneType, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.PhoneType, "", New With {.class = "text-danger"})
            </div>
        </div>



        <div class="form-group">
            @Html.LabelFor(Function(model) model.IsPrivate, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                <div class="checkbox">
                    @Html.EditorFor(Function(model) model.IsPrivate)
                    @Html.ValidationMessageFor(Function(model) model.IsPrivate, "", New With {.class = "text-danger"})
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                @If Model Is Nothing OrElse Model?.MemberID = Guid.Empty Then
                    @<input type = "submit" value="Create" Class="btn btn-default" disabled />
                Else
                    @<input type = "submit" value="Create" Class="btn btn-default" />

                End If


                
            </div>
        </div>
    </div>  

End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")

    @If TempData.ContainsKey("Created") Then

        @if TempData.Item("Created") = False Then

            TempData.Remove("ErrMsg")
        End If

        TempData.Remove("Created")

    End If
End Section
