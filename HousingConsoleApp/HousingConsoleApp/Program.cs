using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingConsoleApp
{
    class Program
    {
        //TODO
        private static PaymentHistoryViewer _PaymentHistoryViewer;
        private static StudentViewer _StudentViewer;

        private static NewStudentCreator _newStudentCreator;

            //viewer executes thing
            //view model is the thing that gets returned

        static void Main(string[] args)
        {
            string menu_return;
            do
            {
                menu_return = MainMenu();
            } while (menu_return != "9");
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

            int room_number;
            long student_id;
            string first_name, last_name, building_name, meal_plan;

            IList<BuildingViewModel> building;
            //TODO ILists

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

            //TODO room 
            for (var i = 0; i < ...)
            {
                Console.WriteLine("Open rooms in " + building_name);
                Console.WriteLine("{0}. {1} {2}", room[i]);
            }
            CommandPrompt("Select open room: ");
            room_number = Console.ReadLine();

            //write meal plan
            Console.WriteLine("Enter student meal plan (1/2/3): ");
            string str_meal_plan = Console.ReadLine();

            //validate meal plan
            if (//TODO)
            {
                Console.WriteLine("Invalid meal plan.  Press any key...");
                Console.ReadKey();
                return;
            }
            else
            {
                meal_plan = str_meal_plan;
            }


            //TODO summary screen
            WriteHeader();
            WriteCreateStudentHeader();
            Console.WriteLine("Student Details:");
            Console.WriteLine("Student Id: " + student_id);
            Console.WriteLine("Name: " + first_name + " " + last_name);
            Console.WriteLine("Building: " + building_name);
            Console.WriteLine("Room number: " + room_number);
            CommandPrompt("Is this correct? (Y/N)");
            string str_response = Console.ReadLine();

            //pass to DTO
            if (str_response.ToLower() == "y")
            {
                NewStudentDTO newStudent = new NewStudentDTO()
                {
                    first_name = first_name,
                    last_name = last_name,
                    building_name = building_name,
                    room_number = room_number
                    meal_plan = meal_plan
                };

            }






        }

        //create payment
            //prompt for studid and payment


        //student payment history report
        public static string PaymentHistoryMenu()
        {
            if (_paymentHistoryViewer == null)
                _PaymentHistoryViewer == new PaymentHisotryViewer();

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

        private static void CommandPrompt(string prompt = "")
        {
            //put the cursor at the bottom of the screen
            Console.CursorTop = Console.WindowHeight - 5;
            Console.WriteLine(prompt == string.Empty ? "Enter command" : prompt + ":");
            Console.Write("# ");
        }










    }
}




