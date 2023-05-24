namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chatsOnUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Chat_ChatId", "dbo.Chats");
            DropIndex("dbo.Users", new[] { "Chat_ChatId" });
            CreateTable(
                "dbo.UserChats",
                c => new
                    {
                        User_UserId = c.Int(nullable: false),
                        Chat_ChatId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserId, t.Chat_ChatId })
                .ForeignKey("dbo.Users", t => t.User_UserId, cascadeDelete: true)
                .ForeignKey("dbo.Chats", t => t.Chat_ChatId, cascadeDelete: true)
                .Index(t => t.User_UserId)
                .Index(t => t.Chat_ChatId);
            
            DropColumn("dbo.Users", "Chat_ChatId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Chat_ChatId", c => c.Int());
            DropForeignKey("dbo.UserChats", "Chat_ChatId", "dbo.Chats");
            DropForeignKey("dbo.UserChats", "User_UserId", "dbo.Users");
            DropIndex("dbo.UserChats", new[] { "Chat_ChatId" });
            DropIndex("dbo.UserChats", new[] { "User_UserId" });
            DropTable("dbo.UserChats");
            CreateIndex("dbo.Users", "Chat_ChatId");
            AddForeignKey("dbo.Users", "Chat_ChatId", "dbo.Chats", "ChatId");
        }
    }
}
