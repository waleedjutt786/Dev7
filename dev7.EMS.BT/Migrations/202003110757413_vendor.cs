namespace dev7.EMS.BT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vendor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vendor",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.Int(nullable: false),
                        Salary = c.Long(nullable: false),
                        Image = c.String(),
                        DateOfJoin = c.DateTime(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        VendorTypeId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        CreatedById = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.Id)
                .ForeignKey("dbo.Company", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.VendorType", t => t.VendorTypeId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.VendorTypeId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.VendorType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Description = c.String(),
                        CreatedById = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vendor", "VendorTypeId", "dbo.VendorType");
            DropForeignKey("dbo.Vendor", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.Vendor", "Id", "dbo.User");
            DropIndex("dbo.Vendor", new[] { "CompanyId" });
            DropIndex("dbo.Vendor", new[] { "VendorTypeId" });
            DropIndex("dbo.Vendor", new[] { "Id" });
            DropTable("dbo.VendorType");
            DropTable("dbo.Vendor");
        }
    }
}
