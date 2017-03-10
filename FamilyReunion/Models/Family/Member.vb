Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Member")>
Partial Public Class Member
    Public Sub New()
        MemberRelationships = New HashSet(Of MemberRelationship)()
        MemberRelationships1 = New HashSet(Of MemberRelationship)()
    End Sub

    Public Property MemberId As Guid

    <Required>
    <StringLength(20)>
    Public Property FirstName As String

    <Required>
    <StringLength(30)>
    Public Property LastName As String

    Public Overridable Property MemberRelationships As ICollection(Of MemberRelationship)

    Public Overridable Property MemberRelationships1 As ICollection(Of MemberRelationship)
End Class
