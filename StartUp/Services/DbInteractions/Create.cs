using StartUp.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartUp.Models.CandidateFolder;
using StartUp.Models;
using System.Net.Mail;

namespace StartUp.Services.DbInteractions
{
    public   class Create
    {
        static   AppDbContext app = new AppDbContext();


        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        //CANDIDATE
        public static void CreateCandidate(string fName, string lName)
        {
            app.Candidates.Add(new  Candidate(fName, lName));
            app.SaveChanges();
        }

        public static void CreateCandidate(string fName, string mName, string lName)
        {
            app.Candidates.Add(new  Candidate(fName, mName, lName));
            app.SaveChanges();
        }

        public static void CreateCandidate(string fName, string mName, string lName, int gender, string
                                           nativeLanguage, DateTime birthdate,string Idtype, int idnumber, DateTime IdIssueDate, 
                                            string email,string address,string alternateAddress , 
                                            string countryOfresidence , string state , string city , int postalCode , string landlineNumber , string mobileNumber)
        {
            var candidate = app.Candidates.Add(new Candidate(fName, mName, lName));
            app.CandidateDetails.Add(
                new CandidateDetails(candidate.CandidateId,gender,nativeLanguage,
                                     birthdate,Idtype,idnumber, IdIssueDate , email,address, alternateAddress , 
                                     countryOfresidence , state ,city , postalCode , landlineNumber ,mobileNumber)
                );
            app.SaveChanges();

        }


        public static void TotalCandidateCreation()
        {
            Console.WriteLine("New Candidate Creation:");
            Console.WriteLine("Type first Name:");
            string fname = Console.ReadLine();
            Console.WriteLine("Type middle Name:");
            string mname = Console.ReadLine();
            Console.WriteLine("Type last Name:");
            string lname = Console.ReadLine();
            int gender = 0;
            do
            {
                //int genderTest = 100;
                Console.WriteLine(" Type : 1 for Male , 2 for Female , 3 for Other");
                try
                {
                    gender = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    Console.WriteLine("Please follow the instructions  ");

                }

            } while (gender > 3 || gender < 1);

            Console.WriteLine("Type Native Language");
            string nativeLanguage = Console.ReadLine();
            //------------------------------------------------------------------------------------
            DateTime birthDate = DateTime.Now.Date;
            do
            {
                Console.WriteLine("Enter a birth date in the form of MM/DD/YY ");
                string input = Console.ReadLine();
                try
                {
                    birthDate = DateTime.Parse(input).Date;
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    Console.WriteLine("Please follow the instructions  ");
                }
                if (birthDate > DateTime.Now.Date)
                {
                    Console.WriteLine("This is a future date. \nPlease follow the instructions:");
                }

            } while (birthDate == DateTime.Now.Date || birthDate > DateTime.Now.Date);

            //Console.WriteLine(birthDate);

            ////------------------------------------------------------------------------------------

            Console.WriteLine("Type Id Type:   National Card/Passport");
            string IdType = Console.ReadLine();

            Console.WriteLine("Type  Id Number:");
            int idnumber = int.Parse(Console.ReadLine());


            ////------------------------------------------------------------------------------------

            DateTime idIssuedate = DateTime.Now.Date;
            do
            {
                Console.WriteLine("Enter an Id issue date in the form of MM/DD/YY ");
                string input = Console.ReadLine();
                try
                {
                    idIssuedate = DateTime.Parse(input).Date;
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    Console.WriteLine("Please follow the instructions  ");
                }
                if (idIssuedate > DateTime.Now.Date)
                {
                    Console.WriteLine("This is a future date. \nPlease follow the instructions:");
                }
                else if (idIssuedate < new DateTime(1900, 1, 1))
                {
                    Console.WriteLine("Please enter a date after 01/01/1900");
                }

            } while (idIssuedate == DateTime.Now.Date || idIssuedate > DateTime.Now.Date || idIssuedate < new DateTime(1900, 1, 1));

            //Console.WriteLine(idIssuedate);
           
            ////-----------------------------------------------------------------------------------

            bool isValidEmail = false;
            string email ;
            do
            {
                Console.WriteLine("Type an email address in the form of: text@example.text");
                email = Console.ReadLine();
                try
                {

                    Console.WriteLine($"The email is {email}");
                    var mail = new MailAddress(email);
                    isValidEmail = mail.Host.Contains(".");
                    if (!isValidEmail)
                    {
                        Console.WriteLine($"The email is invalid");
                    }
                    else
                    {
                        Console.WriteLine($"The email is valid");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine($"The email is invalid");
                }
            } while (!isValidEmail);
            ////-----------------------------------------------------------------------------------
            ////-----------------------------------------------------------------------------------
            Console.WriteLine("Type an address");
            string address = Console.ReadLine();
            Console.WriteLine("Type an alternate address");
            string alternateAdress = Console.ReadLine();
            Console.WriteLine("Type the country Of residence");
            string countryOfresidence = Console.ReadLine();
            Console.WriteLine("Type State");
            string state = Console.ReadLine();
            Console.WriteLine("Type city");
            string city = Console.ReadLine();
            bool key0 ;
            int postalcode = 0;
                    Console.WriteLine("Type the postal Code");
            do
            {
                key0 = false;
                try
                {
                    key0 = false;
                    postalcode = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    key0= true;
                    Console.WriteLine("Please type a proper postal code number");
                } 
            } while (key0);




            Console.WriteLine("Type landline number");
            string landline = Console.ReadLine();
            Console.WriteLine("Type a mobile number");
            string mobile = Console.ReadLine();



            //public static void CreateCandidate(string fName, string mName, string lName, int gender, string
            //                               nativeLanguage, DateTime birthdate, string Idtype, int idnumber, DateTime IdIssueDate,
            //                                string email, string address, string alternateAddress,
            //                                string countryOfresidence, string state, string city, int postalCode, string landlineNumber, string mobileNumber)


            Create.CreateCandidate(fname, mname, lname, gender, nativeLanguage, birthDate.Date, IdType, idnumber, idIssuedate.Date, email, address, alternateAdress, countryOfresidence, state, city, postalcode, landline, mobile);
        }
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        //CERTIFICATES
        public static void CreateCertificate(string title,string topicDescription)
        {
            app.Certificates.Add(new Certificate(title,topicDescription));
            app.SaveChanges();
        }
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        //Attempts
        public static void AddNewAttempt()
        {


        }


    }
}
 