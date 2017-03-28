Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports FamilyReunion
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.Owin

Namespace Controllers
    Public Class MembersController
        Inherits System.Web.Mvc.Controller

        Private db As New FamilyEntities

        ReadOnly Property currentUser As ApplicationUser
            Get
                Dim usr As ApplicationUser = Nothing
                Dim um = System.Web.HttpContext.Current.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
                If User IsNot Nothing Then
                    usr = um.FindById(User.Identity.GetUserId())
                End If
                Return usr
            End Get
        End Property

        ' GET: Members
        Async Function Index() As Task(Of ActionResult)
            Return View(Await db.Members.ToListAsync())
        End Function

        ' GET: Members/Details/5
        Async Function Details(ByVal id As Guid?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim member As Member = Await db.Members.FindAsync(id)
            If IsNothing(member) Then
                Return HttpNotFound()
            End If



            Return View(New ViewModels.MemberDetailsViewModel With {.Member = member,
                        .IsCurrentUser = IsCurrentUser(member)})

        End Function

        Private Function IsCurrentUser(member As Member) As Boolean
            Return Guid.Parse(If(currentUser?.Id, Guid.Empty.ToString)) = member.MemberId
        End Function

        ' GET: Members/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Members/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Create(<Bind(Include:="MemberId,FirstName,LastName, AscendantsFirstName")> ByVal member As Member) As Task(Of ActionResult)
            If ModelState.IsValid Then
                member.MemberId = Guid.NewGuid()
                db.Members.Add(member)
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            Return View(member)
        End Function

        ' GET: Members/Edit/5
        Async Function Edit(ByVal id As Guid?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If

            Dim member As Member = Await db.Members.FindAsync(id)
            If IsNothing(member) Then
                Return HttpNotFound()
            End If
            Dim vm As New ViewModels.MemberEditViewModel(member)
            vm.IsCurrentUser = IsCurrentUser(member)
            Return View(vm)
        End Function

        ' POST: Members/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Edit(<Bind(Include:="Member.MemberId,Member.FirstName,Member.LastName")> ByVal member As ViewModels.MemberEditViewModel) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.Entry(member.Member).State = EntityState.Modified
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            Return View(member)
        End Function

        ' GET: Members/Delete/5
        Async Function Delete(ByVal id As Guid?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim member As Member = Await db.Members.FindAsync(id)
            If IsNothing(member) Then
                Return HttpNotFound()
            End If
            Return View(member)
        End Function

        ' POST: Members/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Async Function DeleteConfirmed(ByVal id As Guid) As Task(Of ActionResult)
            Dim member As Member = Await db.Members.FindAsync(id)
            db.Members.Remove(member)
            Await db.SaveChangesAsync()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
