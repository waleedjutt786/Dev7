namespace dev7.EMS.BT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vendorsalary : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vendor", "Salary");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vendor", "Salary", c => c.Long(nullable: false));
        }
    }
}
