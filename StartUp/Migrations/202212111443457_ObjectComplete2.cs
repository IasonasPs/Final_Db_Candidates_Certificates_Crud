namespace StartUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ObjectComplete2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CandidateDetails", "PhotoIdType", c => c.String());
            DropColumn("dbo.CandidateDetails", "details");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CandidateDetails", "details", c => c.String());
            DropColumn("dbo.CandidateDetails", "PhotoIdType");
        }
    }
}
