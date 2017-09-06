using System;
using System.Data.SqlClient;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class ConsoleUI
    {
        public static string[] MainMenu()
        {
            const int k_NumOfChoices = 8;
            string[] messege = new string[k_NumOfChoices];

            messege[0] = "Show list of vehicles in garage";
            messege[1] = "Add new vehicle to garage";
            messege[2] = "Change vehicle status";
            messege[3] = "Display vehicle info";
            messege[4] = "Fuel vehicle";
            messege[5] = "Charge vehicle";
            messege[6] = "Inflate vehicle's wheels to max";
            messege[7] = "Exit";

            return messege;
        }

        public static int GetOption(int i_numOfChoices)
        {
            string userInput = Console.ReadLine();
            int userChoice;
            bool optionChosenValidator = int.TryParse(userInput, out userChoice);

            if (!optionChosenValidator)
            {
                throw new FormatException("Please enter a number.");
            }

            optionChosenValidator = (userChoice >= 1 && userChoice <= 8);
            if (!optionChosenValidator)
            {
                throw new ValueOutOfRangeException(1,i_numOfChoices);
            }

            return userChoice;
        }

        public static void MenuForUser<T>(T[] i_menuToDisplay)
        {
            int optionNumber = 1;
            Console.Clear();

            foreach (T option in i_menuToDisplay)
            {
                Console.WriteLine("{0}. {1}", optionNumber, option.ToString());
                optionNumber++;
            }

            

        }

        public static void MessegeForUser(string i_messege)
        {
            Console.WriteLine(i_messege);
        }
    }
}
