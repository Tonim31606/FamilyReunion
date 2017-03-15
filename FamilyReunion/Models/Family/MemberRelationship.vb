Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("MemberRelationship")>
Partial Public Class MemberRelationship
    <Key>
    <Column(Order:=0)>
    Public Property MemberID As Guid

    <Key>
    <Column(Order:=1)>
    Public Property RelatedMemberID As Guid

    <Required>
    <StringLength(30)>
    Public Property RelationType As String

    Public Overridable Property Member As Member

    Public Overridable Property RelatedMember As Member
End Class
