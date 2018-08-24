namespace Gnnovation.Sims.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class NewStructure : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Contacts", "Version", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Enterprises", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Enterprises", "Version", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Servers", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Servers", "Version", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AlterColumn("dbo.Contacts", "ModifiedAt", c => c.DateTime());
            AlterColumn("dbo.Enterprises", "ModifiedAt", c => c.DateTime());
            AlterColumn("dbo.Servers", "ModifiedAt", c => c.DateTime());
            DropColumn("dbo.Contacts", "IsActive");
            DropColumn("dbo.Enterprises", "IsActive");
            DropColumn("dbo.Servers", "IsActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Servers", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Enterprises", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Contacts", "IsActive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Servers", "ModifiedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Enterprises", "ModifiedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Contacts", "ModifiedAt", c => c.DateTime(nullable: false));
            DropColumn("dbo.Servers", "Version");
            DropColumn("dbo.Servers", "ModifiedDate");
            DropColumn("dbo.Enterprises", "Version");
            DropColumn("dbo.Enterprises", "ModifiedDate");
            DropColumn("dbo.Contacts", "Version");
            DropColumn("dbo.Contacts", "ModifiedDate");
        }
    }
}
