using System;
using System.Linq;
using System.Net.Mail;
using StartUp.Models.CandidateFolder;
using StartUp.Services.Data;
using StartUp.Services.DbInteractions;
using StartUp.Models;
using System.Runtime.Remoting.Contexts;
namespace StartUp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main starting...");

            AppDbContext context = new AppDbContext();

            Console.WriteLine("------------------------");

            //Read.ReadAllCandidatesLiteEdition();

            //Read.SearchCandidateByLastName("Zorbas");


            Console.WriteLine("------------------------");
            InspectCandidate.InspectCandidatesResults(1);

            //--------------------------------------------------------------------------------------------------------


            Console.WriteLine("The End");



            //Create.TotalCandidateCreation();
        }

        

    }
}
