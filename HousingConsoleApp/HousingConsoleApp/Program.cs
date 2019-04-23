using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Housing.BLL;
using Housing.Entities.DTO;
using Housing.Entities.ViewModels;
using Housing.Entities.Persistence;
using System.Data.SqlClient;

namespace HousingConsoleApp
{
    class Program
    {
        //TODO
        private static PaymentHistoryViewer _paymentHistoryViewer;
        private static StudentViewer _studentViewer;
        private static BuildingViewer _buildingViewer;
        private static RoomViewer _roomViewer;

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
            Console.WriteLine("2. Payment History");
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
            string first_name, last_name, building_name;

            if (_buildingViewer == null)
                _buildingViewer = new BuildingViewer();
            if (_roomViewer == null)
                _roomViewer = new RoomViewer();

            IList<BuildingViewModel> building = _buildingViewer.GetAllBuildingname();
            IList<RoomViewModel> rooms;
            IList<StudentViewModel> students;
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
            for (var i = 0; i<building.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i+1 , building[i].Buildingname);
            }
            //CommandPrompt("Type building name: ");
            Console.WriteLine("Type building name: ");
            building_name = Console.ReadLine();


            //validate building name
            if ((building.Where(dorms => dorms.Buildingname.Trim() == building_name).ToList().Count) == 0) //TODO
            {
                Console.WriteLine("Invalid building entry.  Press any key...");
                Console.ReadKey();
                return;
            }

            //building is valid - grab open rooms
            rooms = _roomViewer.GetOpenRoomsByBuilding(building_name);

            //room 
            for (var i = 0; i < rooms.Count; i++)
            {
                Console.WriteLine("Open rooms in " + building_name);
                Console.WriteLine("{0}. {1} {2}", rooms[i]);
            }
            //CommandPrompt("Select open room: ");
            Console.WriteLine("Select open room: ");
            string str_room_number = Console.ReadLine();


       
            room_number = Convert.ToInt32(str_room_number);

            //summary screen
            WriteHeader();
            WriteCreateStudentHeader();
            Console.WriteLine("Student Details:");
            Console.WriteLine("Student Id: " + student_id);
            Console.WriteLine("Name: " + first_name + " " + last_name);
            Console.WriteLine("Building: " + building_name);
            Console.WriteLine("Room number: " + room_number);
            //TODO meal plan
            CommandPrompt("Is this correct? (Y/N)");
            string str_response = Console.ReadLine();

           
            //pass to DTO
            if (str_response.ToLower() == "y")
            {
                NewStudentDTO newStudent = new NewStudentDTO()
                {
                    StudentID = student_id,
                    Firstname = first_name,
                    Lastname = last_name,
                    Buildingname = building_name,
                    Roomnumber = room_number
                    //TODO meal_plan = meal_plan
                };

                var _creator = new NewStudentCreator();

                _creator.CreateStudent(newStudent);


                Console.WriteLine("Student created successfully.");
                Console.WriteLine("Press any key...");
                Console.ReadKey();
                return;

            }
        }




        //student payment history report
        public static string PaymentHistoryMenu()
        {
            WriteHeader();
            Console.WriteLine("PAYMENT HISTORY:");
            Console.WriteLine();
            Console.WriteLine("1. Run Payment History");
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

            if (_studentViewer == null)
                _studentViewer = new StudentViewer();
            if (_paymentHistoryViewer == null)
                _paymentHistoryViewer = new PaymentHistoryViewer();

            IList<StudentViewModel> student;
            

            WriteHeader();

            Console.WriteLine("Enter student ID: ");
            string str_student_id = (Console.ReadLine());

            student_id = Convert.ToInt64(str_student_id);

   
                //display student name and ask for confirmation

                string student_name = _studentViewer.GetStudent(student_id);
                Console.WriteLine("Student name: {0}" , student_name);

                CommandPrompt("Is this correct? (Y/N)");
                string str_response = Console.ReadLine();
                if (str_response.ToLower() == "y")
                {

                    IList<PaymentViewModel> histories = _paymentHistoryViewer.GetPaymentHistory(student_id);

                    //display payment history
                    

                    Console.Clear();
                    Console.WriteLine("Payment History for " + student_name);
                    Console.WriteLine("###############################################################################################");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();

                    //get data
                    Console.WriteLine("{0,-30} {1,9}", "Payment Date", "Payment Amount");
                    foreach (PaymentViewModel history in histories)
                    {
                        PrintOutSummaryLine(history);
                        
                    }
                    Console.WriteLine("Press any key...");
                    Console.ReadKey();
                    return;
            }
            //}
        }

        /// <param name="history"></param>
        private static void PrintOutSummaryLine(PaymentViewModel history)
        {
            // custom line formatting information is here:
            // https://docs.microsoft.com/en-us/dotnet/standard/base-types/composite-formatting

            //TODO Line formatting

            Console.WriteLine("{0,-30} {1,9:c}", history.Paymentdate, history.PaymentAmount);

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




