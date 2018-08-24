namespace Gnnovation.Sims.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class MoveToNewPla : DbMigration
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
