Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class InitialDB
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.MemberRelationship",
                Function(c) New With
                    {
                        .MemberID = c.Guid(nullable := False),
                        .RelatedMemberID = c.Guid(nullable := False),
                        .RelationType = c.String(nullable := False, maxLength := 30)
                    }) _
                .PrimaryKey(Function(t) New With { t.MemberID, t.RelatedMemberID }) _
                .ForeignKey("dbo.Member", Function(t) t.MemberID) _
                .ForeignKey("dbo.Member", Function(t) t.RelatedMemberID) _
                .Index(Function(t) t.MemberID) _
                .Index(Function(t) t.RelatedMemberID)
            
            CreateTable(
                "dbo.Member",
                Function(c) New With
                    {
                        .MemberId = c.Guid(nullable := False),
                        .FirstName = c.String(nullable := False, maxLength := 20),
                        .LastName = c.String(nullable := False, maxLength := 30)
                    }) _
                .PrimaryKey(Function(t) t.MemberId)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.MemberRelationship", "RelatedMemberID", "dbo.Member")
            DropForeignKey("dbo.MemberRelationship", "MemberID", "dbo.Member")
            DropIndex("dbo.MemberRelationship", New String() { "RelatedMemberID" })
            DropIndex("dbo.MemberRelationship", New String() { "MemberID" })
            DropTable("dbo.Member")
            DropTable("dbo.MemberRelationship")
        End Sub
    End Class
End Namespace
