namespace StartUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Certificate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Certificates", "AssessmentTestCode", c => c.String());
            AddColumn("dbo.Certificates", "TopicDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Certificates", "TopicDescription");
            DropColumn("dbo.Certificates", "AssessmentTestCode");
        }
    }
}
