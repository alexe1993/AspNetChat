namespace TestChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class log : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Visitors",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Url = c.String(),
                        Ip = c.String(),
                        Browser = c.String(),
                        UserAgent = c.String(),
                        UserLanguages = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visitors", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Visitors", new[] { "User_Id" });
            DropTable("dbo.Visitors");
        }
    }
}
