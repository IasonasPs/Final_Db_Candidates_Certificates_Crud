using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartUp.Models.CandidateFolder;
using StartUp.Services.Data;

namespace StartUp.Models
{
    public class Attempt : IDisposable
    {
        AppDbContext app  = new AppDbContext();

        [Key]
        public int  MainId { get; set; }

        public int CandidateId { get; set; }
        public Candidate  Candidate { get; set; }

        public int CertificateId { get; set; }
        public Certificate Certificate { get; set; }

        public DateTime ExamDate { get; set; }
        //---------------------------------------------------------------------------------------------------
       
        public int CandidateScore
        {
            get;
             set;
        }
        private string _pOrf;
        public string PassOrFail 
        {
            get
            {

                if (CandidateScore > 60)
                {
                    _pOrf = "Pass";
                }
                else
                {
                    _pOrf = "Fail";
                }
                return _pOrf;
            }
            private set { }
             
        }
        
        internal Scores Scores { get; set; }
        
        public Attempt()
        {

        }
        public Attempt(int candidateId, int certificateId, DateTime examDate, int candidateScore )
        {
            CandidateId = candidateId;
            CertificateId = certificateId;
            ExamDate = examDate;
            CandidateScore = candidateScore;
         
        }

        public override string ToString()
        {
            var tempCandidate = app.Candidates.Where(c => c.CandidateId == CandidateId).SingleOrDefault();
            var tempCertificate = app.Certificates.Where(c => c.CertificateId == CertificateId).SingleOrDefault();
            return $"Name:{tempCandidate.fName}_{tempCandidate.lName}__Certificate:{tempCertificate.Title}__ExaminationDate:{ExamDate.Month}/{ExamDate.Day}/{ExamDate.Year}" +
                $"__CandidateScore:{CandidateScore}__Result:{PassOrFail}";
        }

        public void Dispose()
        {
           
        }

        


    }





    public class Scores : IDisposable
    {
        [ForeignKey("Attempt")]
        public int ScoresId { get; set; }
        public Attempt Attempt { get; set; }

        public int score1 { get; set; }
        public int score2 { get; set; }
        public int score3 { get; set; }
        public int score4 { get; set; }

        private int _sum;
        public int sum
        {
            get { return _sum = score1 + score2 + score3 + score4; }
            private set {}
        }

        public Scores(int score1, int score2, int score3, int score4)
        {

            this.score1 = score1;
            this.score2 = score2;
            this.score3 = score3;
            this.score4 = score4;

        }

        public Scores()
        {

        }


        public override string ToString()
        {
            return $"Score1:{score1},Score2:{score2},Score3:{score3},Score4:{score4}";
        }
        public void Dispose()
        {
            
        }
    }

}
