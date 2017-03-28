Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class AddMemberAddresses
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Addresses",
                Function(c) New With
                    {
                        .AddressID = c.Long(nullable := False, identity := True),
                        .StreetAddress = c.String(nullable := False, maxLength := 30),
                        .StreetAddress2 = c.String(maxLength := 30),
                        .State = c.String(nullable := False, maxLength := 30),
                        .Zipcode = c.String(nullable := False, maxLength := 30),
                        .MemberID = c.Guid(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.AddressID) _
                .ForeignKey("dbo.Member", Function(t) t.MemberID, cascadeDelete := True) _
                .Index(Function(t) t.MemberID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Addresses", "MemberID", "dbo.Member")
            DropIndex("dbo.Addresses", New String() { "MemberID" })
            DropTable("dbo.Addresses")
        End Sub
    End Class
End Namespace
