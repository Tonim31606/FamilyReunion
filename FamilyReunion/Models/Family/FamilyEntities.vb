Imports System
Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Linq
Imports System.Data.Entity.Infrastructure
Imports System.Data.Entity.Validation

Partial Public Class FamilyEntities
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=FamilyEntities")
    End Sub

    Public Overridable Property Members As DbSet(Of Member)
    Public Overridable Property MemberRelationships As DbSet(Of MemberRelationship)
    Public Overridable Property PhoneNumbers As DbSet(Of PhoneNumber)

    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
        modelBuilder.Entity(Of Member)() _
            .HasMany(Function(e) e.MemberRelationships) _
            .WithRequired(Function(e) e.Member) _
            .HasForeignKey(Function(e) e.MemberID) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of Member)() _
            .HasMany(Function(e) e.RelatedMemersRelationships) _
            .WithRequired(Function(e) e.RelatedMember) _
            .HasForeignKey(Function(e) e.RelatedMemberID) _
            .WillCascadeOnDelete(False)


    End Sub

    Protected Overrides Function ValidateEntity(entityEntry As DbEntityEntry, items As IDictionary(Of Object, Object)) As DbEntityValidationResult
        Dim valid As List(Of DbValidationError) = MyBase.ValidateEntity(entityEntry, items).ValidationErrors.ToList
        If TypeOf entityEntry.Entity Is PhoneNumber Then

            Dim phone As PhoneNumber = CType(entityEntry.Entity, PhoneNumber)
            Dim tmp As IEnumerable(Of DbValidationError) = ValidatePhoneNumber(phone)
            If tmp.Count > 0 Then valid.AddRange(tmp)
        End If
        Return New DbEntityValidationResult(entityEntry, valid)

    End Function

    Private Iterator Function ValidatePhoneNumber(phone As PhoneNumber) As IEnumerable(Of DbValidationError)
        'validate unique phone numbers by member
        If PhoneNumbers.Count(Function(p) p.Phone = phone.Phone AndAlso p.MemberID = phone.MemberID) = 1 Then
            Yield New DbValidationError(NameOf(phone.Phone), "Phone numbers are unique per member.")
        End If
    End Function
End Class
