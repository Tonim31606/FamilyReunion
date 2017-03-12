Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Migrations
Imports System.Linq

Namespace Migrations

    Public NotInheritable Class FamilyMigrationConfiguration
        Inherits DbMigrationsConfiguration(Of FamilyEntities)

        Public Sub New()
            AutomaticMigrationsEnabled = False
            Me.MigrationsDirectory = "Migrations\Family"
        End Sub

        Protected Overrides Sub Seed(context As FamilyEntities)
            '  This method will be called after migrating to the latest version.

            '  You can use the DbSet(Of T).AddOrUpdate() helper extension method 
            '  to avoid creating duplicate seed data. E.g.
            '
            '    context.People.AddOrUpdate(
            '       Function(c) c.FullName,
            '       New Customer() With {.FullName = "Andrew Peters"},
            '       New Customer() With {.FullName = "Brice Lambson"},
            '       New Customer() With {.FullName = "Rowan Miller"})
        End Sub

    End Class

End Namespace
