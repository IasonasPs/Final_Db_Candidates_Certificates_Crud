using StartUp.Models.CandidateFolder;
using StartUp.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace StartUp.Services.DbInteractions
{
    public class Update
    {
       static AppDbContext app = new AppDbContext();

        //---------------------------------------------------------------------------------
        //UpdateCandidate

       

        public static void UpdateCandidate(int Id)
        {
            Candidate candidate = app.Candidates.Find(Id);
            CandidateDetails candidateDetails = app.CandidateDetails.Find(Id);

            bool mainControl;
            do
            {
                mainControl = false;
                Console.WriteLine("Which field of the candidate's information you want to update?");
                Console.WriteLine("Type:\n 1 for first name / 2 for middle name / 3 for last name / 4 for gender / 5 for native language\n" +
                    "/6 for birthDate / 7 for id type / 8 for id number / 9 for Id issue date / 10 for email \n/11 for Address / 12 for alternate address / 13 for Country of residence " +
                    "/ 14 for State / 15 for City \n/16 for postal code / 17 for landline number / 18 for mobile number");
                bool control ;
                int input = 0;
                do
                {
                    try
                    {
                        input = int.Parse(Console.ReadLine());
                        control = false;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Please type an integer");
                        control = true;
                    }
                    if (input < 1 || input >18)
                    {
                        Console.WriteLine("Please type an integer number between 1 and 18.");
                        control = true;
                    }
                } while (control);

                switch (input)
                {
                    case 1:
                        Console.WriteLine("Please type the new first name");
                        candidate.fName = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Please type the new middle name");
                        candidate.mName = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Please type the new last name");
                        candidate.lName = Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine("Please type the new gender");
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
                        candidateDetails.GenderId = gender;
                        break;
                    case 5:
                        Console.WriteLine("Type the new native language");
                        candidateDetails.NativeLanguage= Console.ReadLine();

                        break;
                    case 6:
                        Console.WriteLine("Type the date of birth");
                        DateTime birthDate = DateTime.Now.Date;
                        do
                        {
                            Console.WriteLine("Enter a birth date in the form of MM/DD/YY ");
                            string input2 = Console.ReadLine();
                            try
                            {
                                birthDate = DateTime.Parse(input2).Date;
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
                        candidateDetails.BirthDate = birthDate;
                        break;
                    case 7:
                        Console.WriteLine("Type the new Id type (National Card/Passport)");
                        candidateDetails.PhotoIdType= Console.ReadLine();
                        break;
                    case 8:
                        Console.WriteLine("Type the new Id number ");
                        candidateDetails.PhotoIdNumber = int.Parse(Console.ReadLine());
                        break;
                    case 9:
                        Console.WriteLine("Type the new issue date of the Id");
                        DateTime idIssuedate = DateTime.Now.Date;
                        do
                        {
                            Console.WriteLine("Enter an Id issue date in the form of MM/DD/YY ");
                            string input3 = Console.ReadLine();
                            try
                            {
                                idIssuedate = DateTime.Parse(input3).Date;
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
                        candidateDetails.PhotoIdIssueDate= idIssuedate;

                        break;
                    case 10:
                        Console.WriteLine("Type the new email");
                        bool isValidEmail = false;
                        string email = "";
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
                        candidateDetails.Email = email;
                        break;
                    case 11:
                        Console.WriteLine("Type the new address");
                        candidateDetails.Address = Console.ReadLine();
                        break;
                    case 12:
                        Console.WriteLine("Type the new alternate address");
                        candidateDetails.AlternateAddress = Console.ReadLine();
                        break;
                    case 13:
                        Console.WriteLine("Type the new Country of residence");
                        candidateDetails.CountryOfresidence = Console.ReadLine();
                        break;
                    case 14:
                        Console.WriteLine("Type the new state");
                        candidateDetails.State = Console.ReadLine();
                        break;
                    case 15:
                        Console.WriteLine("Type the new City");
                        candidateDetails.City = Console.ReadLine();
                        break;
                    case 16:
                        Console.WriteLine("Type the new postal code");
                        candidateDetails.PostalCode = int.Parse( Console.ReadLine() );
                        break;
                    case 17:
                        Console.WriteLine("Type the new landline number");
                        candidateDetails.LandlineNumber = Console.ReadLine();
                        break;
                    case 18:
                        Console.WriteLine("Type the new mobile number");
                        candidateDetails.MobileNumber= Console.ReadLine();
                        break;
                        //------------
                }
                        app.SaveChanges();

                Console.WriteLine("Do u want to update any other field?");
                Console.WriteLine("If yes then press 5");
                int lastDecision = 0;
                try
                {
                     lastDecision = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                if (lastDecision == 5)
                {
                    mainControl = true;
                }
                else
                {

                    Console.WriteLine("Thank you for choosing our method for your Update");
                }


            } while (mainControl);



            app.SaveChanges();
        }


    }
}
