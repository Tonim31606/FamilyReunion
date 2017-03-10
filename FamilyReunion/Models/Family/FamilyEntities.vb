Imports System
Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Linq

Partial Public Class FamilyEntities
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=FamilyEntities")
    End Sub

    Public Overridable Property Members As DbSet(Of Member)
    Public Overridable Property MemberRelationships As DbSet(Of MemberRelationship)

    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
        modelBuilder.Entity(Of Member)() _
            .HasMany(Function(e) e.MemberRelationships) _
            .WithRequired(Function(e) e.Member) _
            .HasForeignKey(Function(e) e.MemberID) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of Member)() _
            .HasMany(Function(e) e.RelatedMemersRelationships) _
            .WithRequired(Function(e) e.RelagedMember) _
            .HasForeignKey(Function(e) e.RelatedMemberID) _
            .WillCascadeOnDelete(False)
    End Sub
End Class
