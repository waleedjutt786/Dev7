namespace dev7.EMS.BT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class schedules : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        CompanyId = c.Int(nullable: false),
                        CreatedById = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Schedule",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        AddressLine = c.String(),
                        City = c.String(),
                        Province = c.String(),
                        Country = c.String(),
                        ZipCode = c.Int(nullable: false),
                        CreatedById = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Event", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedule", "Id", "dbo.Event");
            DropForeignKey("dbo.Event", "CompanyId", "dbo.Company");
            DropIndex("dbo.Schedule", new[] { "Id" });
            DropIndex("dbo.Event", new[] { "CompanyId" });
            DropTable("dbo.Schedule");
            DropTable("dbo.Event");
        }
    }
}
