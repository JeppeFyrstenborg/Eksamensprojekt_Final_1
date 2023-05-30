namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelValidation_1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Chats", "ChatName", c => c.String(nullable: false, maxLength: 80));
            AlterColumn("dbo.Messages", "MessageText", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 80));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "Username", c => c.String());
            AlterColumn("dbo.Messages", "MessageText", c => c.String());
            AlterColumn("dbo.Chats", "ChatName", c => c.String());
        }
    }
}
