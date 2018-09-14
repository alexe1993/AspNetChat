namespace TestChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class log_ation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Visitors", "ActionInfo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Visitors", "ActionInfo");
        }
    }
}
