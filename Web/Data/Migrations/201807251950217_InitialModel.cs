namespace Gnnovation.SIMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EnterpriseID = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        MiddleName = c.String(),
                        LastName = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Enterprises",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ShortName = c.String(),
                        FullName = c.String(),
                        Address = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Enterprises");
            DropTable("dbo.Contacts");
        }
    }
}
