Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class AddMemberphonenumbers
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.PhoneNumbers",
                Function(c) New With
                    {
                        .PhoneID = c.Long(nullable := False, identity := True),
                        .Phone = c.String(nullable := False, maxLength := 18),
                        .PhoneType = c.String(nullable := False, maxLength := 20),
                        .MemberID = c.Guid(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.PhoneID) _
                .ForeignKey("dbo.Member", Function(t) t.MemberID, cascadeDelete := True) _
                .Index(Function(t) t.MemberID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.PhoneNumbers", "MemberID", "dbo.Member")
            DropIndex("dbo.PhoneNumbers", New String() { "MemberID" })
            DropTable("dbo.PhoneNumbers")
        End Sub
    End Class
End Namespace
