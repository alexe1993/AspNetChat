namespace TestChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChatMessage : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Chats", newName: "ChatMessages");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ChatMessages", newName: "Chats");
        }
    }
}
