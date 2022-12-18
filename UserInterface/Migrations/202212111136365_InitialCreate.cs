namespace StartUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attempts",
                c => new
                    {
                        MainId = c.Int(nullable: false, identity: true),
                        Comments = c.String(),
                        Candidate_CandidateId = c.Int(),
                        Certificate_CertificateId = c.Int(),
                    })
                .PrimaryKey(t => t.MainId)
                .ForeignKey("dbo.Candidates", t => t.Candidate_CandidateId)
                .ForeignKey("dbo.Certificates", t => t.Certificate_CertificateId)
                .Index(t => t.Candidate_CandidateId)
                .Index(t => t.Certificate_CertificateId);
            
            CreateTable(
                "dbo.Candidates",
                c => new
                    {
                        CandidateId = c.Int(nullable: false, identity: true),
                        fName = c.String(),
                        mName = c.String(),
                        lName = c.String(),
                    })
                .PrimaryKey(t => t.CandidateId);
            
            CreateTable(
                "dbo.CandidateDetails",
                c => new
                    {
                        CandidateDetailsId = c.Int(nullable: false),
                        details = c.String(),
                        GenderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CandidateDetailsId)
                .ForeignKey("dbo.Candidates", t => t.CandidateDetailsId)
                .ForeignKey("dbo.Genders", t => t.GenderId, cascadeDelete: true)
                .Index(t => t.CandidateDetailsId)
                .Index(t => t.GenderId);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        GenderId = c.Int(nullable: false, identity: true),
                        GenderName = c.String(),
                    })
                .PrimaryKey(t => t.GenderId);
            
            CreateTable(
                "dbo.Certificates",
                c => new
                    {
                        CertificateId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.CertificateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attempts", "Certificate_CertificateId", "dbo.Certificates");
            DropForeignKey("dbo.Attempts", "Candidate_CandidateId", "dbo.Candidates");
            DropForeignKey("dbo.CandidateDetails", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.CandidateDetails", "CandidateDetailsId", "dbo.Candidates");
            DropIndex("dbo.CandidateDetails", new[] { "GenderId" });
            DropIndex("dbo.CandidateDetails", new[] { "CandidateDetailsId" });
            DropIndex("dbo.Attempts", new[] { "Certificate_CertificateId" });
            DropIndex("dbo.Attempts", new[] { "Candidate_CandidateId" });
            DropTable("dbo.Certificates");
            DropTable("dbo.Genders");
            DropTable("dbo.CandidateDetails");
            DropTable("dbo.Candidates");
            DropTable("dbo.Attempts");
        }
    }
}
