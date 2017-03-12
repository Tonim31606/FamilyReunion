Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class PrivatePhonenumbers
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.PhoneNumbers", "IsPrivate", Function(c) c.Boolean(nullable := False))
        End Sub
        
        Public Overrides Sub Down()
            DropColumn("dbo.PhoneNumbers", "IsPrivate")
        End Sub
    End Class
End Namespace
