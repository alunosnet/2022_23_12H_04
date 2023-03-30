namespace M17E_Lar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Familiars",
                c => new
                    {
                        FamiliarID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Morada = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false),
                        Telefone = c.String(nullable: false, maxLength: 9),
                    })
                .PrimaryKey(t => t.FamiliarID);
            
            CreateTable(
                "dbo.Visitas",
                c => new
                    {
                        ID_Visita = c.Int(nullable: false, identity: true),
                        ID = c.Int(nullable: false),
                        ID_Idoso = c.Int(nullable: false),
                        DataVisita = c.DateTime(nullable: false),
                        RelacaoFamiliar = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID_Visita)
                .ForeignKey("dbo.Familiars", t => t.ID, cascadeDelete: true)
                .ForeignKey("dbo.Idosoes", t => t.ID_Idoso, cascadeDelete: true)
                .Index(t => t.ID)
                .Index(t => t.ID_Idoso);
            
            CreateTable(
                "dbo.Idosoes",
                c => new
                    {
                        ID_Idoso = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Data_Nasc = c.DateTime(nullable: false),
                        Doenças = c.String(maxLength: 400),
                        NUtenteSaude = c.String(nullable: false, maxLength: 9),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Idoso);
            
            CreateTable(
                "dbo.Utilizadors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Perfil = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visitas", "ID_Idoso", "dbo.Idosoes");
            DropForeignKey("dbo.Visitas", "ID", "dbo.Familiars");
            DropIndex("dbo.Visitas", new[] { "ID_Idoso" });
            DropIndex("dbo.Visitas", new[] { "ID" });
            DropTable("dbo.Utilizadors");
            DropTable("dbo.Idosoes");
            DropTable("dbo.Visitas");
            DropTable("dbo.Familiars");
        }
    }
}
