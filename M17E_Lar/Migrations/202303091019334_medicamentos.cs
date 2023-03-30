namespace M17E_Lar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class medicamentos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medicamentoes",
                c => new
                    {
                        ID_Medicamento = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Contra = c.String(maxLength: 400),
                        Dose = c.String(nullable: false, maxLength: 2),
                        Forma = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID_Medicamento);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Medicamentoes");
        }
    }
}
