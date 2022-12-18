namespace StartUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Scores2nd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attempts", "ExamDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Attempts", "CandidateScore", c => c.Int(nullable: false));
            DropColumn("dbo.Attempts", "Comments");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Attempts", "Comments", c => c.String());
            DropColumn("dbo.Attempts", "CandidateScore");
            DropColumn("dbo.Attempts", "ExamDate");
        }
    }
}
