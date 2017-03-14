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

Namespace Controllers
    Public Class PhoneNumbersController
        Inherits System.Web.Mvc.Controller

        Private db As New FamilyEntities

        ' GET: PhoneNumbers
        Async Function Index(id As Guid?) As Task(Of ActionResult)
            Dim phoneNumbers As List(Of PhoneNumber)
            If id.HasValue Then
                Dim mbr As Member = Await db.Members.FindAsync(id)
                If mbr Is Nothing Then
                    phoneNumbers = New List(Of PhoneNumber)
                Else
                    phoneNumbers = mbr.PhoneNumbers.ToList
                End If
            Else
                phoneNumbers = Await db.PhoneNumbers.ToListAsync()
            End If
            Return View(phoneNumbers)
        End Function

        ' GET: PhoneNumbers/Details/5
        Async Function Details(ByVal id As Long?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim phoneNumber As PhoneNumber = Await db.PhoneNumbers.FindAsync(id)
            If IsNothing(phoneNumber) Then
                Return HttpNotFound()
            End If
            Return View(phoneNumber)
        End Function

        ' GET: PhoneNumbers/Create
        Async Function Create(MemberID As Guid?) As Task(Of ActionResult)
            If MemberID.HasValue Then
                Dim mbr As Member = Await db.Members.FindAsync(MemberID.Value)
                If mbr IsNot Nothing Then Return View(New PhoneNumber With {.MemberID = MemberID.Value})
            End If
            Return View()
        End Function

        ' POST: PhoneNumbers/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Create(<Bind(Include:="PhoneID,Phone,PhoneType,MemberID,IsPrivate")> ByVal phoneNumber As PhoneNumber) As Task(Of ActionResult)
            If ModelState.IsValid Then

                Try
                    db.PhoneNumbers.Add(phoneNumber)
                    Await db.SaveChangesAsync()
                    TempData.Add("Created", True)
                    Return RedirectToAction("Create", New With {.MemberID = phoneNumber.MemberID})
                Catch ex As Exception
                    TempData.Add("Created", False)
                    TempData.Add("ErrMsg", String.Join("  ", ex.FullExceptionMessages))
                End Try
            End If
            Return View(phoneNumber)
        End Function

        ' GET: PhoneNumbers/Edit/5
        Async Function Edit(ByVal id As Long?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim phoneNumber As PhoneNumber = Await db.PhoneNumbers.FindAsync(id)
            If IsNothing(phoneNumber) Then
                Return HttpNotFound()
            End If
            Return View(phoneNumber)
        End Function

        ' POST: PhoneNumbers/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Edit(<Bind(Include:="PhoneID,Phone,PhoneType,MemberID,IsPrivate")> ByVal phoneNumber As PhoneNumber) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.Entry(phoneNumber).State = EntityState.Modified
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            Return View(phoneNumber)
        End Function

        ' GET: PhoneNumbers/Delete/5
        Async Function Delete(ByVal id As Long?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim phoneNumber As PhoneNumber = Await db.PhoneNumbers.FindAsync(id)
            If IsNothing(phoneNumber) Then
                Return HttpNotFound()
            End If
            Return View(phoneNumber)
        End Function

        ' POST: PhoneNumbers/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Async Function DeleteConfirmed(ByVal id As Long) As Task(Of ActionResult)
            Dim phoneNumber As PhoneNumber = Await db.PhoneNumbers.FindAsync(id)
            db.PhoneNumbers.Remove(phoneNumber)
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
