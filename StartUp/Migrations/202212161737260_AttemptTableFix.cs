namespace StartUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AttemptTableFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attempts", "Candidate_CandidateId", "dbo.Candidates");
            DropForeignKey("dbo.Attempts", "Certificate_CertificateId", "dbo.Certificates");
            DropIndex("dbo.Attempts", new[] { "Candidate_CandidateId" });
            DropIndex("dbo.Attempts", new[] { "Certificate_CertificateId" });
            RenameColumn(table: "dbo.Attempts", name: "Candidate_CandidateId", newName: "CandidateId");
            RenameColumn(table: "dbo.Attempts", name: "Certificate_CertificateId", newName: "CertificateId");
            AddColumn("dbo.Attempts", "PassOrFail", c => c.String());
            AlterColumn("dbo.Attempts", "CandidateId", c => c.Int(nullable: false));
            AlterColumn("dbo.Attempts", "CertificateId", c => c.Int(nullable: false));
            CreateIndex("dbo.Attempts", "CandidateId");
            CreateIndex("dbo.Attempts", "CertificateId");
            AddForeignKey("dbo.Attempts", "CandidateId", "dbo.Candidates", "CandidateId", cascadeDelete: true);
            AddForeignKey("dbo.Attempts", "CertificateId", "dbo.Certificates", "CertificateId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attempts", "CertificateId", "dbo.Certificates");
            DropForeignKey("dbo.Attempts", "CandidateId", "dbo.Candidates");
            DropIndex("dbo.Attempts", new[] { "CertificateId" });
            DropIndex("dbo.Attempts", new[] { "CandidateId" });
            AlterColumn("dbo.Attempts", "CertificateId", c => c.Int());
            AlterColumn("dbo.Attempts", "CandidateId", c => c.Int());
            DropColumn("dbo.Attempts", "PassOrFail");
            RenameColumn(table: "dbo.Attempts", name: "CertificateId", newName: "Certificate_CertificateId");
            RenameColumn(table: "dbo.Attempts", name: "CandidateId", newName: "Candidate_CandidateId");
            CreateIndex("dbo.Attempts", "Certificate_CertificateId");
            CreateIndex("dbo.Attempts", "Candidate_CandidateId");
            AddForeignKey("dbo.Attempts", "Certificate_CertificateId", "dbo.Certificates", "CertificateId");
            AddForeignKey("dbo.Attempts", "Candidate_CandidateId", "dbo.Candidates", "CandidateId");
        }
    }
}
