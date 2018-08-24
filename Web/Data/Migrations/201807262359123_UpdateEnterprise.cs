namespace Gnnovation.SIMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEnterprise : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "CreatedBy", c => c.String());
            AlterColumn("dbo.Contacts", "ModifiedBy", c => c.String());
            AlterColumn("dbo.Enterprises", "CreatedBy", c => c.String());
            AlterColumn("dbo.Enterprises", "ModifiedBy", c => c.String());
            AlterColumn("dbo.Servers", "CreatedBy", c => c.String());
            AlterColumn("dbo.Servers", "ModifiedBy", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Servers", "ModifiedBy", c => c.String(nullable: false));
            AlterColumn("dbo.Servers", "CreatedBy", c => c.String(nullable: false));
            AlterColumn("dbo.Enterprises", "ModifiedBy", c => c.String(nullable: false));
            AlterColumn("dbo.Enterprises", "CreatedBy", c => c.String(nullable: false));
            AlterColumn("dbo.Contacts", "ModifiedBy", c => c.String(nullable: false));
            AlterColumn("dbo.Contacts", "CreatedBy", c => c.String(nullable: false));
        }
    }
}
