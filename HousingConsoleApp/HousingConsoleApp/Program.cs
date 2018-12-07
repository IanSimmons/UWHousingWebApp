using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingConsoleApp
{
    class Program
    {

        private static PaymentHistoryViewer _PaymentHistoryViewer;

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
                    menu_return = PaymentHistoryMenu();
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

            int room_no;
            long student_id;
            string first_name, last_name, building_name, meal_plan;

            IList<BuildingViewModel> building;

            WriteHeader();
            WriteCreateStudentHeader();

            //get student ID
            Console.WriteLine("Enter Student ID: ");
            string str_student_id = (Console.ReadLine());

            //validate student ID
            if (!Int64.TryParse(str_student_id, out student_id) || student_id > 9079999999 || student_id < 9070000000)
            {
                Console.WriteLine("Invalid student ID.  Press any key...");
                Console.ReadKey();
                return;
            }

            //input first and last name
            Console.WriteLine("Enter student first name: ");
            first_name = Console.ReadLine();
            Console.WriteLine("Enter student last name: ");
            last_name = Console.ReadLine();

            //write building names on screen
            for (var i = 0; i < building.Count; i++)
            {
                Console.WriteLine("{0}. {1} {2}", building[i]);
            }
            CommandPrompt("Type building name: ");
            building_name = Console.ReadLine();

            //validate building name
            if (building.Contains(building_name))
            {
                Console.WriteLine("Invalid building entry.  Press any key...");
                Console.ReadKey();
                return;
            }

            //room TODO
            for (var i = 0; i < ...)
            {
                Console.WriteLine("Open rooms in " + building_name);
                Console.WriteLine("{0}. {1} {2}", room[i]);
            }
            CommandPrompt("Select open room: ");
            room_no = Console.ReadLine();


            //summary screen TODO

            //confirmation
            CommandPrompt("Is this correct? (Y/N)");
            string str_response = Console.ReadLine();

            //pass to DTO
            if (str_response.ToLower() == "y")
            {
                NewStudentDTO newStudent = new NewStudentDTO()
                {
                    //TODO
                }

            }






        }

        //create payment
        //prompt for studid and payment


        //student payment history report
        public static string PaymentHistoryMenu()
        {
            WriteHeader();
            Console.WriteLine("ORDER SUMMARY:");
            Console.WriteLine();
            Console.WriteLine("1. Run Order Summary");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("9. Return to the Main Menu");
            CommandPrompt("Enter menu option");
            string selection = Console.ReadLine();

            if (selection == "1")
            {
                RunPaymentHistory();
            }
            else if (selection != "9")
            {
                Console.WriteLine("Invalid entry.");
                Console.WriteLine("Press any key....");
                Console.ReadKey();

            }

            return selection;



        }

        //runs the payment history
        private static void RunPaymentHistory()
        {
            long student_id;

            WriteHeader();

            Console.WriteLine("Enter student ID: ");
            string str_student_id = (Console.ReadLine());

            //validate student ID
            if (!Int64.TryParse(str_student_id, out student_id) || student_id > 9079999999 || student_id < 9070000000)
            {
                Console.WriteLine("Invalid student ID.  Press any key...");
                Console.ReadKey();
                return;
            }
            else
            {
                
                //display student name and ask for confirmation
                
                //display payment history
                IList<PaymentHistoryViewModel> history = _paymentHistoryViewer.Get
                
                Console.Clear();
                Console.WriteLine("Payment History for " + first_name + last_name);
                Console.WriteLine("###############################################################################################");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

            }

        }










        //Write Header
        private static void WriteHeader()
        {
            Console.Clear();
            Console.WriteLine("#### UW Housing Resident Management System ####");
            Console.WriteLine();
            Console.WriteLine();
        }

        private static void WriteCreateStudentHeader()
        {
            Console.WriteLine();
            Console.WriteLine("Create New Student");
            Console.WriteLine("#######################");
            Console.WriteLine();
            Console.WriteLine();
        }
        










    }
}




