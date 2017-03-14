Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations.Application
    Public Partial Class RemoveMemberIDfromuser
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropColumn("dbo.AspNetUsers", "MemberID")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.AspNetUsers", "MemberID", Function(c) c.Guid())
        End Sub
    End Class
End Namespace
