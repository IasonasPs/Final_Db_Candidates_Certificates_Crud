namespace StartUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AttemptTableFixScoresId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attempts", "ScoresId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attempts", "ScoresId");
        }
    }
}
