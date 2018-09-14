namespace TestChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class log_action_fix : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Visitors", "ActionInfo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Visitors", "ActionInfo", c => c.String());
        }
    }
}
