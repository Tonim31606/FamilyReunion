Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Member")>
Partial Public Class Member
    Public Sub New()
        MemberRelationships = New HashSet(Of MemberRelationship)()
        RelatedMemersRelationships = New HashSet(Of MemberRelationship)()
        PhoneNumbers = New HashSet(Of PhoneNumber)
    End Sub
    <Key>
    Public Property MemberId As Guid = Guid.NewGuid

    <Required>
    <StringLength(20)>
    <Display(Name:="First Name")>
    Public Property FirstName As String

    <Required>
    <StringLength(30)>
    <Display(Name:="Last Name")>
    Public Property LastName As String

    Public Overridable Property MemberRelationships As ICollection(Of MemberRelationship)

    Public Overridable Property RelatedMemersRelationships As ICollection(Of MemberRelationship)

    Public Overridable Property PhoneNumbers As ICollection(Of PhoneNumber)
End Class
