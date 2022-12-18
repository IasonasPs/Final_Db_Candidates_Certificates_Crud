using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using StartUp.Services.DbInteractions;

namespace UserInterface.Menus
{
    internal class AdminService
    {

        public static void Admin(int Password)
        {

            //int password = ;


            bool key0 ;
                Console.WriteLine("Welcome!");
            do
            {
                key0 = false;
                Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
                Console.WriteLine("If you want to Create,Read,Update or Delete a specific candidate type: 1");
                Console.WriteLine("If you want to inspect a candidates Results type: 2");
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
                switch ( userInput)
                {
                case 1:
                    //------------------------------------------------------------------------------------------------------------------------
                    //------------------------------------------------------------------------------------------------------------------------
                    //CANDIDATES CRUD
                        bool key1;
                        do
                        {
                            key1 = false;
                            Console.WriteLine("Type 1 for Create, 2 for Read, 3 for Update, 4 for Delete");
                            int Input = 0;
                            //Input VALIDATION
                            while (Input != 1 && Input != 2 && Input != 3 && Input != 4)
                            {
                                try
                                {
                                    Input = int.Parse(Console.ReadLine());
                                    if (Input != 1 && Input != 2 && Input != 3 && Input != 4)
                                    {
                                        throw new Exception();
                                    }
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Please type 1,2,3 or 4");
                                }
                            }

                            switch (Input)
                            {

                                case 1:
                                    Create.TotalCandidateCreation();
                                    break;
                                //-----------------------------------------------------------------------------
                                case 2:
                                    bool key3;
                                    do
                                    {
                                        key3 = false;
                                        CandidatesTableInspection();
                                        Console.WriteLine("Type the last name of the candidate you are searching:");
                                        string lname = Console.ReadLine();
                                        Read.SearchCandidateByLastName(lname);

                                        Console.WriteLine("Do you want to search for other Candidates?");
                                        Console.WriteLine("If yes press 4 else 6.");
                                        int k3 = 0;
                                        while (k3 != 4 && k3 != 6)
                                        {
                                            try
                                            {
                                                k3 = int.Parse(Console.ReadLine());
                                                if (k3 != 4 && k3 != 6)
                                                {
                                                    throw new Exception();
                                                }
                                            }
                                            catch (Exception)
                                            {
                                                Console.WriteLine("Please type 4  to continue else press 6 to exit");
                                            }
                                        }
                                        if (k3 == 4)
                                        {
                                            key3 = true;
                                        }
                                        Console.WriteLine("---------------------------------------------------------------------------------");
                                    } while (key3);
                                    break;
                                //-----------------------------------------------------------------------------
                                case 3:
                                    //ReadAllCandidates (if you want)
                                    bool key2;
                                    do
                                    {
                                        key2 = false;
                                        CandidatesTableInspection();
                                        //UpdateCandidate
                                        Console.WriteLine("Type the last name of the candidate you want to update.");
                                        string laname = Console.ReadLine();
                                        int thisId = (Read.GetIdByLastName(laname));
                                        if (thisId != 0)
                                        {
                                            Update.UpdateCandidate(thisId);
                                        }
                                        else
                                        {
                                            Console.WriteLine("It is now certain that this candidate does not exist");
                                        }
                                        Console.WriteLine("Do you want to update any other candidate or try again?");
                                        Console.WriteLine("If the answer is 'Yes' then press 4 else press 6.");
                                        int k2 = 0;
                                        while (k2 != 4 && k2 != 6)
                                        {
                                            try
                                            {
                                                k2 = int.Parse(Console.ReadLine());
                                                if (k2 != 4 && k2 != 6)
                                                {
                                                    throw new Exception();
                                                }
                                            }
                                            catch (Exception)
                                            {
                                                Console.WriteLine("Please type 4 if you want to update else press 6 to exit");
                                            }
                                        }
                                        if (k2 == 4)
                                        {
                                            key2 = true;
                                        }
                                        Console.WriteLine("---------------------------------------------------------------------------------");
                                    } while (key2);
                                    break;
                                //-----------------------------------------------------------------------------
                                case 4:
                                    bool key5;
                                    do
                                    {
                                        key5 = false;
                                        CandidatesTableInspection();
                                        Console.WriteLine("Type the last name of the candidate you want to delete.");
                                        string lasname = Console.ReadLine();
                                        int thiscId = (Read.GetIdByLastName(lasname));
                                        if (thiscId != 0)
                                        {
                                            Delete.DeleteCandidate(thiscId);
                                        }
                                        Console.WriteLine("Do you want to delete any other candidates or try again?");
                                        Console.WriteLine("If the answer is 'Yes' then press 4 else press 6");
                                        int k5 = 0;
                                        while (k5 != 4 && k5 != 6)
                                        {
                                            try
                                            {
                                                k5 = int.Parse(Console.ReadLine());
                                                if (k5 != 4 && k5 != 6)
                                                {
                                                    throw new Exception();
                                                }
                                            }
                                            catch (Exception)
                                            {
                                                Console.WriteLine("Please type 4 if you want to delete a candidate else press 6 to exit");
                                            }
                                        }
                                        if (k5 == 4)
                                        {
                                            key5 = true;
                                        }

                                        Console.WriteLine("---------------------------------------------------------------------------------");
                                    } while (key5);
                                    break;  
                            }
                            //-----------------------------------------------------------------------------
                            Console.WriteLine("Press 4 if you want to reUse the C.R.U.D. menu, or press 6 to exit");
                            int k1 = 0;
                            while (k1 != 4 && k1 != 6)
                            {
                                try
                                {
                                    k1 = int.Parse(Console.ReadLine());
                                    if (k1 != 4 && k1 != 6)
                                    {
                                        throw new Exception();
                                    }
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Please type 4 if you want to delete a candidate else press 6 to exit");
                                }
                            }
                            if (k1 == 4)
                            {
                                key1 = true;
                            }
                        } while (key1);
                                break;
                    //-----------------------------------------------------------------------------
                    //-----------------------------------------------------------------------------
                    //-----------------------------------------------------------------------------
                case 2:
                        bool key7;
                        do
                        {
                            key7 = false;
                            Console.WriteLine("Welcome to the results menu!");
                            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - -");
                            CandidatesTableInspection();
                            Console.WriteLine("Please type the last name of the candidate whose results you want to inspect");
                            string last = Console.ReadLine();
                            int candidateID;
                            try
                            {
                                  candidateID = Read.GetIdByLastName(last);
                                  InspectCandidate.InspectCandidatesResults(candidateID);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Rechecking if this candidate exists");
                                Thread.Sleep(2200);
                                Console.WriteLine("We are sorry...There is no such candidate.");
                            }

                            //-----------------------------------------------------------------------------
                            Console.WriteLine("Do you want to reuse the Results-Inspection menu?");
                            Console.WriteLine("If 'Yes' then press 4  else press 6 to exit");
                            int k7 = 0;
                            while (k7 != 4 && k7 != 6)
                            {
                                try
                                {
                                    k7 = int.Parse(Console.ReadLine());
                                    if (k7 != 4 && k7 != 6)
                                    {
                                        throw new Exception();
                                    }
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Please type 4 if you want to reuse the menu or press 6 to exit");
                                }
                            }
                            if (k7 == 4)
                            {
                                key7 = true;
                            }

                        } while (key7);
                                break;
                    //-----------------------------------------------------------------------------
                    //-----------------------------------------------------------------------------
                    //-----------------------------------------------------------------------------
                }
                Console.WriteLine("Do you want to reuse the Admin's Service menu?");
                Console.WriteLine("If 'Yes' then press 4  else press 6 to exit");
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





        internal static void CandidatesTableInspection()
        {
            Console.WriteLine("If you first need to see a table of all candidates press 4 else press 6");
            int dt = 0;
            while (dt != 4 && dt != 6)
            {
                try
                {
                    dt = int.Parse(Console.ReadLine());
                    if (dt != 4 && dt != 6)
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please type 4 if you want to see a table of all Candidates else press 6");
                }
            }
            if (dt == 4)
            {
                Read.ReadAllCandidatesLiteEdition();
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
