namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DatosContactoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Telefono = c.String(),
                        Correo = c.String(),
                        DatosPersonalesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DatosPersonales", t => t.DatosPersonalesId, cascadeDelete: true)
                .Index(t => t.DatosPersonalesId);
            
            CreateTable(
                "dbo.DatosPersonales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        ApellidoPaterno = c.String(),
                        ApellidoMaterno = c.String(),
                        Direccion = c.String(),
                        EstadoId = c.Int(nullable: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estadoes", t => t.EstadoId, cascadeDelete: true)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.Estadoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DatosContactoes", "DatosPersonalesId", "dbo.DatosPersonales");
            DropForeignKey("dbo.DatosPersonales", "EstadoId", "dbo.Estadoes");
            DropIndex("dbo.DatosPersonales", new[] { "EstadoId" });
            DropIndex("dbo.DatosContactoes", new[] { "DatosPersonalesId" });
            DropTable("dbo.Estadoes");
            DropTable("dbo.DatosPersonales");
            DropTable("dbo.DatosContactoes");
        }
    }
}
