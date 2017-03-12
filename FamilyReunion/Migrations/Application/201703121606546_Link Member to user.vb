Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations.Application
    Public Partial Class LinkMembertouser
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.AspNetUsers", "MemberID", Function(c) c.Guid())
        End Sub
        
        Public Overrides Sub Down()
            DropColumn("dbo.AspNetUsers", "MemberID")
        End Sub
    End Class
End Namespace
