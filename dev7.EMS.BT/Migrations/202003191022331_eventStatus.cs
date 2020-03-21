namespace dev7.EMS.BT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Event", "EventStatus", c => c.Int(nullable: false));
            AlterColumn("dbo.Schedule", "ZipCode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Schedule", "ZipCode", c => c.Int(nullable: false));
            DropColumn("dbo.Event", "EventStatus");
        }
    }
}
