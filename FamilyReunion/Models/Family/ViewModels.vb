Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace ViewModels
    Public Class PhoneListViewModel


        Property PhoneNumbers As IEnumerable(Of PhoneNumber)
        Property Member As Member
        Property HidePrivate As Boolean = True



    End Class


    Public Class MemberDetailsViewModel
        Property Member As Member
        Property IsCurrentUser As Boolean

    End Class

    Public Class MemberEditViewModel

        Sub New(Member As Member)

            Me.Member = Member


        End Sub

        Property Member As Member


        Property IsCurrentUser As Boolean = False
    End Class

End Namespace
