namespace M17E_Lar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jaime : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MedicaIdosoes",
                c => new
                    {
                        ID_MedicaIdoso = c.Int(nullable: false, identity: true),
                        ID_Medicamento = c.Int(nullable: false),
                        ID_Idoso = c.Int(nullable: false),
                        data_inicio = c.DateTime(nullable: false),
                        data_fim = c.DateTime(nullable: false),
                        Dose = c.String(nullable: false, maxLength: 2),
                        Obs = c.String(),
                    })
                .PrimaryKey(t => t.ID_MedicaIdoso)
                .ForeignKey("dbo.Idosoes", t => t.ID_Idoso, cascadeDelete: true)
                .ForeignKey("dbo.Medicamentoes", t => t.ID_Medicamento, cascadeDelete: true)
                .Index(t => t.ID_Medicamento)
                .Index(t => t.ID_Idoso);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicaIdosoes", "ID_Medicamento", "dbo.Medicamentoes");
            DropForeignKey("dbo.MedicaIdosoes", "ID_Idoso", "dbo.Idosoes");
            DropIndex("dbo.MedicaIdosoes", new[] { "ID_Idoso" });
            DropIndex("dbo.MedicaIdosoes", new[] { "ID_Medicamento" });
            DropTable("dbo.MedicaIdosoes");
        }
    }
}
