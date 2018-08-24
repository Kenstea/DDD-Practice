namespace  Gnnovation.Sims.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class ContactAndServer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Servers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(maxLength: 255),
                        StatusId = c.Int(nullable: false),
                        EnterpriseID = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Enterprises", t => t.EnterpriseID, cascadeDelete: true)
                .Index(t => t.EnterpriseID);
            
            AlterColumn("dbo.Enterprises", "ShortName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Enterprises", "FullName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Enterprises", "Address", c => c.String(nullable: false, maxLength: 300));
            CreateIndex("dbo.Contacts", "EnterpriseID");
            AddForeignKey("dbo.Contacts", "EnterpriseID", "dbo.Enterprises", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Servers", "EnterpriseID", "dbo.Enterprises");
            DropForeignKey("dbo.Contacts", "EnterpriseID", "dbo.Enterprises");
            DropIndex("dbo.Servers", new[] { "EnterpriseID" });
            DropIndex("dbo.Contacts", new[] { "EnterpriseID" });
            AlterColumn("dbo.Enterprises", "Address", c => c.String());
            AlterColumn("dbo.Enterprises", "FullName", c => c.String());
            AlterColumn("dbo.Enterprises", "ShortName", c => c.String());
            DropTable("dbo.Servers");
        }
    }
}
