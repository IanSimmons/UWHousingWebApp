using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        //main menu method
        public static string MainMenu()
        {
            WriteHeader();
            Console.WriteLine("MAIN MENU:");
            Console.WriteLine();
            Console.WriteLine("1. Create Student");
            Console.WriteLine("2. Create Payment");
            Console.WriteLine("3. Payment Summary");
            Console.WriteLine("4. Building Capacity Report");
            Console.WriteLine("");
            Console.WriteLine("9. Exit");

            CommandPrompt("Enter menu option");
            string selection = Console.ReadLine();

            if (selection == "1")
            {
                CreateStudent();
            }
            else if (selection == "2")
            {

            }
            else if (selection == "3")
            {
                string menu_return;
                do
                {
                    menu_return = PaymentSummaryMenu();
                } while (menu_return != "9");
            }
            else if (selection == "4")
            {
                do
                {
                    menu_return = BuildingCapacityMenu();
                } while (menu_return != "9");
            }
            else if (selection != "9")
            {
                Console.WriteLine("Invalid entry.");
                Console.WriteLine("Press any key....");
                Console.ReadKey();
            }

            return selection;

        }

        //create student

        private static void CreateStudent()
        {

            int student_id, room_no;
            string first_name, last_name, building, meal_plan;



        }

        //create payment
        //prompt for studid and payment


        //building capcity report

        //stduent payment history report

    }
}




