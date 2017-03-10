Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Public Class PhoneNumber
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    <Key>
    <Display(Name:="Phone ID")>
    Property PhoneID As Long
    <Required>
    <StringLength(18)>
    <Phone>
    <Display(Name:="Phone Number")>
    Property Phone As String
    <Required>
    <StringLength(20)>
    <Display(Name:="Phone Type")>
    Property PhoneType As String
    <Required>
    Property MemberID As Guid
    <Required>
    <Display(Name:="Private?")>
    Property IsPrivate As Boolean = False

    Overridable Property Member As Member

End Class
