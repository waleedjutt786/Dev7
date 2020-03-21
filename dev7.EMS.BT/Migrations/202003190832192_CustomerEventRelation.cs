namespace dev7.EMS.BT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerEventRelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Event", "CustomerId", c => c.Int());
            CreateIndex("dbo.Event", "CustomerId");
            AddForeignKey("dbo.Event", "CustomerId", "dbo.Customer", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Event", "CustomerId", "dbo.Customer");
            DropIndex("dbo.Event", new[] { "CustomerId" });
            DropColumn("dbo.Event", "CustomerId");
        }
    }
}
