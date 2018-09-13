namespace TestChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chats",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Text = c.String(),
                        Time = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Chats", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Chats", new[] { "User_Id" });
            DropTable("dbo.Chats");
        }
    }
}
