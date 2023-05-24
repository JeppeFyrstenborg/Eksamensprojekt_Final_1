namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dteTime_messages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "CreatedTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "CreatedTime");
        }
    }
}
