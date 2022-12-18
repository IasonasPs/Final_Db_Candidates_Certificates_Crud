using StartUp.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUp.Services.DbInteractions
{
    public class InspectCandidate
    {
        
        
        
        public static void InspectCandidatesResults(int input)
        {
            AppDbContext context = new AppDbContext();

            int temp = input;

            int id = context.Candidates.Where(c => c.CandidateId == temp).SingleOrDefault().CandidateId;

            var list = context.Attempts.Where(a => a.CandidateId == id).ToList();

            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }
        }









    }
}
