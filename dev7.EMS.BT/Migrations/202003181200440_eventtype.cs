namespace dev7.EMS.BT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventtype : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Description = c.String(),
                        CompanyId = c.Int(nullable: false),
                        CreatedById = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventType", "CompanyId", "dbo.Company");
            DropIndex("dbo.EventType", new[] { "CompanyId" });
            DropTable("dbo.EventType");
        }
    }
}
