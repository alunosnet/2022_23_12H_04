namespace M17E_Lar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class medicamentoatt : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Medicamentoes", "Dose");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Medicamentoes", "Dose", c => c.String(nullable: false, maxLength: 2));
        }
    }
}
