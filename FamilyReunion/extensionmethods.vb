﻿
Imports System.Data.Entity.Validation
Imports System.Runtime.CompilerServices

Module extensionmethods
    <Extension>
    Iterator Function ExceptionStack(ex As Exception) As IEnumerable(Of Exception)
        Yield ex
        If ex.InnerException IsNot Nothing Then
            For Each exc In ex.InnerException.ExceptionStack
                Yield exc
            Next
        End If
    End Function
    <Extension>
    Function FullExceptionMessages(ex As DbEntityValidationException) As IEnumerable(Of String)
        Return ex.EntityValidationErrors.SelectMany(Function(e) e.ValidationErrors).Select(Function(e) e.ErrorMessage)
    End Function
    <Extension>
    Function FullExceptionMessages(ex As Exception) As IEnumerable(Of String)
        Return ex.ExceptionStack.Select(Function(e) e.Message)
    End Function


End Module
