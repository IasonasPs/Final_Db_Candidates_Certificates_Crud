namespace StartUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Certificate1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Certificates", "AssessmentTestCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Certificates", "AssessmentTestCode", c => c.String());
        }
    }
}
