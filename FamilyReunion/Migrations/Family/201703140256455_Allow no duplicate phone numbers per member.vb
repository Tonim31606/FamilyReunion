Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Allownoduplicatephonenumberspermember
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropIndex("dbo.PhoneNumbers", New String() { "MemberID" })
            CreateIndex("dbo.PhoneNumbers", New String() { "Phone", "MemberID" }, unique := True, name := "MemberPhone")
        End Sub
        
        Public Overrides Sub Down()
            DropIndex("dbo.PhoneNumbers", "MemberPhone")
            CreateIndex("dbo.PhoneNumbers", "MemberID")
        End Sub
    End Class
End Namespace
