namespace  Gnnovation.Sims.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddMigrationEnterprise : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Servers", new[] { "EnterpriseID" });
            CreateIndex("dbo.Servers", "EnterpriseId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Servers", new[] { "EnterpriseId" });
            CreateIndex("dbo.Servers", "EnterpriseID");
        }
    }
}
