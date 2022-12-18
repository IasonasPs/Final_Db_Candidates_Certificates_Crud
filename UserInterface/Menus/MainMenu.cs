using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPdf;
using System.Drawing;
namespace UserInterface.Menus
{
    internal class MainMenu
    {
        public static void GrandMenu()
        {
            bool key;
            do
            {
                key = false;
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");

                Console.WriteLine("<Administrators Code>: 01123");
                Console.WriteLine("<Candidates Code>:2357      ");
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
                Console.WriteLine("Welcome....");
                Console.WriteLine("Please enter the code that you were given.");
                bool key0 = false;
                int password = 0;
                do
                {
                    try
                    {
                        password = int.Parse(Console.ReadLine());
                        key0 = false;
                    }
                    catch (Exception)
                    {

                        key0 = true;
                        Console.WriteLine("Please type a sequence of integers");
                    }
                } while (key0);
                switch (password)
                {

                    case 01123:
                        AdminService.Admin(0);
                        break;

                    case 2357:
                        CandidateService.CandidateUI(0);
                        break;

                    default:
                        Console.WriteLine("We are sorry.The password that you typed is wrong");
                        break;
                }
                Console.WriteLine("If you want to Continue press space");
                var control = Console.ReadKey();
                if (control.Key.ToString() == "Spacebar")
                {
                    key = true;
                }
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");

            } while (key);
            
            




        }











    }
}
