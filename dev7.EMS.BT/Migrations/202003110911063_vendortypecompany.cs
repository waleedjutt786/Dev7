namespace dev7.EMS.BT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vendortypecompany : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VendorType", "CompanyId", c => c.Int());
            CreateIndex("dbo.VendorType", "CompanyId");
            AddForeignKey("dbo.VendorType", "CompanyId", "dbo.Company", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VendorType", "CompanyId", "dbo.Company");
            DropIndex("dbo.VendorType", new[] { "CompanyId" });
            DropColumn("dbo.VendorType", "CompanyId");
        }
    }
}
