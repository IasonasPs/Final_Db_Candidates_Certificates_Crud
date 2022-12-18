using StartUp.Models.CandidateFolder;
using StartUp.Services.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUp.Services.DbInteractions
{
    public class Read
    {
        static AppDbContext app = new AppDbContext();

        //---------------------------------------------------------------------------------
        //ReadCandidate
        public static void ReadAllCandidatesLiteEdition()
        {
            var myList = app.Candidates.ToList();
            foreach (var item in myList)
            {
                Console.WriteLine(item);
                Console.WriteLine("- - - - - -  - - - - -");
            }

        }
        public static void ReadAllCandidates()
        {
            var myList = app.Candidates.ToList();
            foreach (var item in myList)
            {
                Console.WriteLine(item);
                var details = app.CandidateDetails.Where(x => x.CandidateDetailsId == item.CandidateId).SingleOrDefault();
                Console.WriteLine(details);
                Console.WriteLine("- - - - - -  - - - - -");
            }
        }

        public static void SearchCandidateById(int Id)
        {
            try
            {
                var candidate = app.Candidates.Where(x => x.CandidateId == Id).Single();
                Console.WriteLine(candidate);
                var details = app.CandidateDetails.Where(x => x.CandidateDetailsId == candidate.CandidateId).Single();
                Console.WriteLine(details);
            }
            catch (Exception e)
            {
                Console.WriteLine($"There is no Candidate with Id={Id}");
                Console.WriteLine(e.Message);
            }
        }

        public static void SearchCandidateByLastName(string lname)
        {
            try
            {
                var temp = app.Candidates.Where(c => c.lName == lname);
                if (temp.Count() == 0)
                {
                    throw new NotFoundException();
                }
                var candidate = temp.Single();
                Console.WriteLine(candidate.ToString());
                var details = app.CandidateDetails.Find(candidate.CandidateId);
                Console.WriteLine(details);
            }
            catch (NotFoundException)
            {
                Console.WriteLine("The candidate you are looking for does not exist");
            }
            catch (Exception)
            {
                Console.WriteLine("There are more Candidates with the same Last name");
                Console.WriteLine("Please enter candidates  first name:");
                string temp = Console.ReadLine();
                Console.WriteLine(temp);
                var candidate = app.Candidates.Where(c => c.lName == lname).Where(c => c.fName == temp).Single();
                Console.WriteLine(candidate.ToString());

                var details = app.CandidateDetails.Find(candidate.CandidateId);
                Console.WriteLine(details);
            }



        }

        public static int GetIdByLastName(string lname)
        {
            try
            {
                var temp = app.Candidates.Where(c => c.lName == lname);
                if (temp.Count() == 0)
                {
                    throw new NotFoundException();
                }
                var candidate = temp.Single();

                return candidate.CandidateId;
            }
            catch (NotFoundException)
            {
                Console.WriteLine("The candidate you are looking for does not exist");
                return 0;
            }
            catch (Exception)
            {
                Console.WriteLine("There are more Candidates with the same Last name");
                Console.WriteLine("Please enter candidates  first name:");
                string temp = Console.ReadLine();
                var candidate = app.Candidates.Where(c => c.lName == lname).Where(c => c.fName == temp).Single();
                return candidate.CandidateId;
            }
        }


    
    }
}
