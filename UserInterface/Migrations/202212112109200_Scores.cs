namespace StartUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Scores : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Scores",
                c => new
                    {
                        ScoresId = c.Int(nullable: false),
                        score1 = c.Int(nullable: false),
                        score2 = c.Int(nullable: false),
                        score3 = c.Int(nullable: false),
                        score4 = c.Int(nullable: false),
                        sum = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ScoresId)
                .ForeignKey("dbo.Attempts", t => t.ScoresId)
                .Index(t => t.ScoresId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Scores", "ScoresId", "dbo.Attempts");
            DropIndex("dbo.Scores", new[] { "ScoresId" });
            DropTable("dbo.Scores");
        }
    }
}
