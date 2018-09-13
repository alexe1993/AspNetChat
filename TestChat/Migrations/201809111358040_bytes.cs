namespace TestChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bytes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Avatar", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Avatar");
        }
    }
}
