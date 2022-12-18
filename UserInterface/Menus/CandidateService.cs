using StartUp.Services.Data;
using StartUp.Services.DbInteractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UserInterface.Menus
{
    internal  class CandidateService
    {
        static AppDbContext app = new AppDbContext();

        public static void CandidateUI(int Password)
        {
            //int password = ;
            bool key0;
            Console.WriteLine("Welcome!");
            do
            {
                key0 = false;
                Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
                Console.WriteLine("If you want to see a List of your aquired Certificates type:1");
                Console.WriteLine("If you want to export the list of your certificates in a pdf file type:2");
                Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
                int userInput = 0;
                //userInput Validation
                while (userInput != 1 && userInput != 2)
                {
                    try
                    {
                        userInput = int.Parse(Console.ReadLine());
                        if (userInput != 1 && userInput != 2)
                        {
                            throw new Exception();
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Please type 1 or 2 ");
                    }
                }
                switch (userInput)
                {
                    case 1:
                        //------------------------------------------------------------------------------------------------------------------------
                        //------------------------------------------------------------------------------------------------------------------------
                        //LIST OF CERTIFICATES
                        bool key2;
                        do
                        {
                            key2 = false;
                            AdminService.CandidatesTableInspection();
                            Console.WriteLine("Please type your last name");
                            string lastname = Console.ReadLine();
                            int cId = (Read.GetIdByLastName(lastname));

                            var list = app.Attempts.Where(a => a.CandidateId == cId).ToList();
                            int counter = 0;
                            foreach (var item in list)
                            {

                                if (item.PassOrFail == "Pass")
                                {
                                    counter++;
                                    Console.WriteLine(item.ToString()); 
                                }

                            }
                            if (counter == 0)
                            {
                                Console.WriteLine("We are sorry.There are no acquired certificates in our database");
                                Console.WriteLine("------------------------------------------------------------------------");
                            }
                            

                        } while (key2);

                        break;
                    //-----------------------------------------------------------------------------
                    //-----------------------------------------------------------------------------
                    //PDF EXPORTATION
                    case 2:

                        ListOfCertificatesPdfCreation();
                        Console.WriteLine("");
                        break;
                        //-----------------------------------------------------------------------------
                        //-----------------------------------------------------------------------------
                        //-----------------------------------------------------------------------------
                }
                Console.WriteLine("Do you want to reuse the Service menu?");
                Console.WriteLine("If 'Yes' then press 4 ,else press 6 to exit");
                int k0 = 0;
                while (k0 != 4 && k0 != 6)
                {
                    try
                    {
                        k0 = int.Parse(Console.ReadLine());
                        if (k0 != 4 && k0 != 6)
                        {
                            throw new Exception();
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Please type 4 if you want to reuse the menu or press 6 to exit");
                    }
                }
                if (k0 == 4)
                {
                    key0 = true;
                }
            } while (key0);

        }

        public static void ListOfCertificatesPdfCreation()
        {
            int cId = 0;
            Console.WriteLine("Please type your last name");
            string lastname = Console.ReadLine();
            try
            {
                var temp = app.Candidates.Where(c => c.lName == lastname);

                if (temp.Count() == 0)
                {
                    throw new NotFoundException();
                }
                else
                {
                    cId = temp.Single().CandidateId;
                }
            }
            catch (NotFoundException)
            {
                Console.WriteLine("You dont exist....");
                
            }
            catch (Exception)
            {
                Console.WriteLine("There are more Candidates with the same Last name");
                Console.WriteLine("Please enter your  first name:");
                string temp = Console.ReadLine();
                var candidate = app.Candidates.Where(c => c.lName == lastname).Where(c => c.fName == temp).Single();
                cId = candidate.CandidateId;
            }

            if (cId != 0)
            {
                var name = app.Candidates.Where(c => c.CandidateId == cId).Single();
                var list = app.Attempts.Where(a => a.CandidateId == cId).ToList();
                int counter = 0;
                string pdfContent = $"<h3>List of Certificates of Candidate:</h3><h4>{name.fName} {name.lName}</h4><hr>";
                pdfContent += "<ol>";


                foreach (var item in list)
                {
                    if (item.PassOrFail == "Pass")
                    {
                        counter++;
                        pdfContent += $"<li>{item.ToString()}</li>";
                    }
                }
                if (counter == 0)
                {
                    Console.WriteLine("No certificates");
                    return;
                }
                pdfContent += "</ol><hr>";
                pdfContent += "<h4>Congratulations!</h4>";

                var Renderer = new IronPdf.ChromePdfRenderer();
                var PDF = Renderer.RenderHtmlAsPdf(pdfContent);
                var OutputPath = "ChromePdfRenderer.pdf";
                PDF.SaveAs(OutputPath);
                //------------------------------------------------------------------------------------
                System.Diagnostics.Process.Start(OutputPath);
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -"); 
            }
        }
















    }
}
