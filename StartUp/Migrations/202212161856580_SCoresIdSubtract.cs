namespace StartUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SCoresIdSubtract : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Attempts", "ScoresId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Attempts", "ScoresId", c => c.Int(nullable: false));
        }
    }
}
