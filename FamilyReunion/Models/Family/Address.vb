Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Class Address

    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    <Key>
    <Display(Name:="Address ID")>
    Property AddressID As Long

    <Required>
    <Display(Name:="Street Address")>
    <MaxLength(30)>
    Public Property StreetAddress As String


    <Display(Name:="Street Address 2")>
    <MaxLength(30)>
    Public Property StreetAddress2 As String

    <Required>
    <Display(Name:="State")>
    <MaxLength(30)>
    Public Property State As String

    <Required>
    <Display(Name:="Zipcode")>
    <MaxLength(30)>
    Public Property Zipcode As String

    Public Property MemberID As Guid

    Public Overridable Property Member As Member

End Class
