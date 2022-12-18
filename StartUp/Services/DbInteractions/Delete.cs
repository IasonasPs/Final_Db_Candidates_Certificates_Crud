using StartUp.Models;
using StartUp.Models.CandidateFolder;
using StartUp.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StartUp.Services.DbInteractions
{
    public class Delete
    {

        static AppDbContext app = new AppDbContext();
        static AppDbContext app2 = new AppDbContext();
        static AppDbContext app3 = new AppDbContext();


        //---------------------------------------------------------------------------------
        //DeleteCandidate
        public static void DeleteCandidate(int Id)
        {
            Candidate candidate = app.Candidates.Find(Id);
            var attempts = app.Attempts.Where(a => a.CandidateId == candidate.CandidateId).ToList();

            foreach (var item in attempts)
            {
                var score = app2.Scores.Find(item.MainId);
                app2.Scores.Remove(score);
                var tempAttempt = app2.Attempts.Find(item.MainId);
                app2.Attempts.Remove(tempAttempt);
                app2.SaveChanges();
            }
            deleteMainObjectCandidate(Id);
            //------------------------------------------------------------------------------------------------------------------------------------------------
        }

        private static void deleteMainObjectCandidate(int Id)
        {
            var candidead = app3.Candidates.Remove(app3.Candidates.Find(Id));
            app3.CandidateDetails.Remove(app3.CandidateDetails.Find(Id));
            Console.WriteLine($"This Candidate was deleted :{candidead.fName}_{candidead.lName}");
            app3.SaveChanges();
        }
    }
}
