Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class AddAscendantsFirstNametomember
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.Member", "AscendantsFirstName", Function(c) c.String(nullable := False, maxLength := 30))
        End Sub
        
        Public Overrides Sub Down()
            DropColumn("dbo.Member", "AscendantsFirstName")
        End Sub
    End Class
End Namespace
