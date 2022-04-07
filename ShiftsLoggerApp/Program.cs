using System;

namespace ShiftsLoggerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            Console.WriteLine("Welcome to Shifts Logger.\n\n");

            Console.WriteLine("Press any key for Main Menu\n\n");

            Console.ReadLine();

            bool CloseApp = false;

            while (CloseApp != true)
            {
                Console.Clear();

                Console.WriteLine("Main Menu\n\n");

                Console.WriteLine("Select an option from the menu below to get started, or press 0 to close the App.\n\n");

                Console.WriteLine("1. View Shift Log\n2. Add Shift\n3. Update Shift\n4. Delete Shift\n\n");

                string UserInput = Console.ReadLine();

                int UserChoice = -1;

                bool realNumber = int.TryParse (UserInput, out UserChoice);

                while (realNumber == false || UserChoice < 0 || UserChoice > 4)
                {
                    Console.Clear();

                    Console.WriteLine("Main Menu\n\n");

                    Console.WriteLine("Error: Select an option from the menu below to get started, or press 0 to close the App.\n\n");

                    Console.WriteLine("1. View Shift Log\n2. Add Shift\n3. Update Shift\n4. Delete Shift\n\n");

                    UserInput = Console.ReadLine();

                    UserChoice = -1;

                    realNumber = int.TryParse (UserInput, out UserChoice);
                }

                switch (UserChoice)
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Closing Shift Logger.. Goodbye!");
                        CloseApp = true;
                    break;
                    case 1:
                        UserMenu.GetData();
                    break;
                    case 2:
                        UserMenu.AddData();
                    break;
                    case 3:
                        UserMenu.UpdateData();
                    break;
                    case 4:
                        UserMenu.DeleteData();
                    break;
                }
            }
        }
    }
}
