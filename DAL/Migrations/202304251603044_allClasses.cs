namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allClasses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chats",
                c => new
                    {
                        ChatId = c.Int(nullable: false, identity: true),
                        ChatName = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ChatId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Email = c.String(),
                        Chat_ChatId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Chats", t => t.Chat_ChatId)
                .Index(t => t.Chat_ChatId);
            
            CreateTable(
                "dbo.UserAuths",
                c => new
                    {
                        UserAuthId = c.Int(nullable: false, identity: true),
                        HashedPassword = c.String(),
                        Salt = c.String(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.UserAuthId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            AddColumn("dbo.Messages", "User_UserId", c => c.Int());
            AddColumn("dbo.Messages", "Chat_ChatId", c => c.Int());
            CreateIndex("dbo.Messages", "User_UserId");
            CreateIndex("dbo.Messages", "Chat_ChatId");
            AddForeignKey("dbo.Messages", "User_UserId", "dbo.Users", "UserId");
            AddForeignKey("dbo.Messages", "Chat_ChatId", "dbo.Chats", "ChatId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAuths", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "Chat_ChatId", "dbo.Chats");
            DropForeignKey("dbo.Messages", "Chat_ChatId", "dbo.Chats");
            DropForeignKey("dbo.Messages", "User_UserId", "dbo.Users");
            DropIndex("dbo.UserAuths", new[] { "User_UserId" });
            DropIndex("dbo.Users", new[] { "Chat_ChatId" });
            DropIndex("dbo.Messages", new[] { "Chat_ChatId" });
            DropIndex("dbo.Messages", new[] { "User_UserId" });
            DropColumn("dbo.Messages", "Chat_ChatId");
            DropColumn("dbo.Messages", "User_UserId");
            DropTable("dbo.UserAuths");
            DropTable("dbo.Users");
            DropTable("dbo.Chats");
        }
    }
}
