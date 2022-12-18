namespace StartUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ObjectComplete : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CandidateDetails", "NativeLanguage", c => c.String());
            AddColumn("dbo.CandidateDetails", "BirthDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.CandidateDetails", "PhotoIdNumber", c => c.Int(nullable: false));
            AddColumn("dbo.CandidateDetails", "PhotoIdIssueDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.CandidateDetails", "Email", c => c.String());
            AddColumn("dbo.CandidateDetails", "Address", c => c.String());
            AddColumn("dbo.CandidateDetails", "AlternateAddress", c => c.String());
            AddColumn("dbo.CandidateDetails", "CountryOfresidence", c => c.String());
            AddColumn("dbo.CandidateDetails", "State", c => c.String());
            AddColumn("dbo.CandidateDetails", "City", c => c.String());
            AddColumn("dbo.CandidateDetails", "PostalCode", c => c.Int(nullable: false));
            AddColumn("dbo.CandidateDetails", "LandlineNumber", c => c.String());
            AddColumn("dbo.CandidateDetails", "MobileNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CandidateDetails", "MobileNumber");
            DropColumn("dbo.CandidateDetails", "LandlineNumber");
            DropColumn("dbo.CandidateDetails", "PostalCode");
            DropColumn("dbo.CandidateDetails", "City");
            DropColumn("dbo.CandidateDetails", "State");
            DropColumn("dbo.CandidateDetails", "CountryOfresidence");
            DropColumn("dbo.CandidateDetails", "AlternateAddress");
            DropColumn("dbo.CandidateDetails", "Address");
            DropColumn("dbo.CandidateDetails", "Email");
            DropColumn("dbo.CandidateDetails", "PhotoIdIssueDate");
            DropColumn("dbo.CandidateDetails", "PhotoIdNumber");
            DropColumn("dbo.CandidateDetails", "BirthDate");
            DropColumn("dbo.CandidateDetails", "NativeLanguage");
        }
    }
}
