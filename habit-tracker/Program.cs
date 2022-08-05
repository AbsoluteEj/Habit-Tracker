using System;
using Microsoft.Data.Sqlite;

namespace habit_tracker
{
    class Program
    {
        static void Main(string[] args)
        {

            // Create Database
            string connectionString = @"Data Source=habit-Tracker.db";

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText =
                    @"CREATE TABLE IF NOT EXISTS drink_water (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Date TEXT,
                        Quantity INTEGER
                        )";

                tableCmd.ExecuteNonQuery();

                connection.Close();
            }
        }
        // =========== Main Menu ============== //
        GetUserInput();
        static void GetUserInput()
        {
            Console.Clear();

            bool isRunning = true;

            // selections or options //
            while (isRunning == true)
            {
                Console.WriteLine("========== MAIN MENU =========\n");
                Console.WriteLine("Welcome to Habit Tracker: Track your glasses of water!\n");

                Console.WriteLine("Please choose from the options below to interact with your records:\n");

                Console.WriteLine("Type 0 to close the application");
                Console.WriteLine("Type 1 to view all previous records");
                Console.WriteLine("Type 2 to insert/create a record");
                Console.WriteLine("Type 3 to update a record");
                Console.WriteLine("Type 4 to delete a record");
                Console.WriteLine("----------------------------------------------------------------------");

                string select = Console.ReadLine();

                switch (select.Trim())
                {
                    case "0":
                        Console.WriteLine("Thank you for using!");
                        isRunning = false;
                        break;
                    case "1":
                        Retrieve();
                        break;
                    case "2":
                        Create();
                        break;
                    case "3":
                        Update();
                        break;
                    case "4":
                        Delete();
                        break;
                    default:
                        Console.WriteLine("Invalid Input! Please only type from 0 - 4."); // can create new method when return back to main menu
                        break;
                }
            }
        }


        private static void Create()
        {
            string date = GetDateInput();

        }

        internal static string GetDateInput()
        {
            Console.WriteLine("Please enter the date in this format: mm-dd-yyyy. Type 0 to return to main menu.\n");

            string dateInput = Console.ReadLine();

            if (dateInput == "0") GetUserInput();

        }
    }
}