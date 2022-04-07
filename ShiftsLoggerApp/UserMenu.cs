using System;
using ConsoleTableExt;

namespace ShiftsLoggerApp
{
    public class UserMenu
    {
        public static void GetData() {
            Console.Clear();

            Console.WriteLine("Retrieve Shift Data\n\n");

            Console.WriteLine("Logged shifts can be found below.\n");

            var ShiftList = Controller.GetShiftsList();

            ConsoleTableBuilder
                .From(ShiftList)
                .ExportAndWrite();

            Console.WriteLine("\n\nPress any key to return to main menu.\n\n");

            Console.ReadLine();
        }

        public static void AddData() {
            Console.Clear();

            Console.WriteLine("Add Shift Data\n\n");

            Console.WriteLine("Answer each question below to Log a new shift");

            Console.WriteLine("What is the shift start date? (2022-01-01");

            DateTime StartTime = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("What is the shift end date? (2022-01-01");

            DateTime EndTime = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("How many hours is the shift?");

            decimal Hours = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("What is the location of the shift?");

            string Location = Console.ReadLine();

            decimal Minutes = Hours * 60;

            decimal Pay = Minutes * Convert.ToDecimal(12.00);

            Controller.SendShift(StartTime, EndTime, Minutes, Pay, Location);

            Console.WriteLine("Shift Logged. Press any key to return to main menu");

            Console.ReadLine();
        }

        public static void UpdateData() {
            Console.WriteLine("Update Shift Data\n\n");

            Console.ReadLine();
        }

        public static void DeleteData() {
            Console.WriteLine("Delete Shift Data\n\n");

            Console.ReadLine();
        }


    }
}