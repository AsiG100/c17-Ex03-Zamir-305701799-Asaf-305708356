using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Enums;

namespace Ex03.ConsoleUI
{
    class GarageUI
    {
        private Garage m_garage = new Garage();

        public enum eMainMunu
        {
            VehicleList = 1,
            AddNewVehicle,
            ChangeVehicleCondition,
            VehicleInfo,
            FuelVehicle,
            ChargeVehicle,
            InflateWheelsToMax,
            Exit
        };

        private int handleChoice(int i_menuOptionsLength)
        {
            int userChoice = 0;
            bool optionChosenValidator = false;

            do
            {
                try
                {
                    userChoice = ConsoleUI.GetOption(i_menuOptionsLength);
                    optionChosenValidator = true;
                }
                catch (FormatException ex)
                {
                    ConsoleUI.MessegeForUser(ex.Message);
                    optionChosenValidator = false;
                }
                catch (ValueOutOfRangeException ex)
                {
                    ConsoleUI.MessegeForUser(ex.Message);
                    optionChosenValidator = false;
                }
            } while (!optionChosenValidator);

            return userChoice;
        }

        public void RunGarage()
        {
            eMainMunu userSelection = 0;

            do
            {
                Console.Clear();
                string[] mainMenu = ConsoleUI.MainMenu();
                ConsoleUI.MenuForUser(mainMenu);
                Console.Write("\nChoose an option: ");
                int userChoice = handleChoice(mainMenu.Length);
                userSelection = (eMainMunu) Enum.Parse(typeof(eMainMunu), userChoice.ToString());
                Console.Clear();
                switch (userSelection)
                {
                    case eMainMunu.VehicleList:
                    {
                        ShowVehicleList();
                        break;
                    }
                    case eMainMunu.AddNewVehicle:
                    {
                        AddVehicleToGarage();
                        break;
                    }
                    case eMainMunu.ChangeVehicleCondition:
                    {
                        ChangeVehicleCondition();
                        break;
                    }
                    case eMainMunu.VehicleInfo:
                    {
                        DisplayVehicleInfo();
                        break;
                    }
                    case eMainMunu.FuelVehicle:
                    {
                        FuelVehicle();
                        break;
                    }
                    case eMainMunu.ChargeVehicle:
                    {
                        ChargeVehicle();
                        break;
                    }
                    case eMainMunu.InflateWheelsToMax:
                    {
                        InflateWheelsToMax();
                        break;
                    }
                }

            } while (userSelection != eMainMunu.Exit);
        }

        private void ShowVehicleList()
        {
            string[] displayOptions = new string[2];

            displayOptions[0] = "All vehicles in garage";
            displayOptions[1] = "Get vehicles by treatment condition";

            ConsoleUI.MenuForUser(displayOptions);

            int userSelection = handleChoice(displayOptions.Length);
            const int k_AllVehicles = 1;
            const int k_someVehicles = 2;
            List<string> vehicleList = new List<string>();

            if (userSelection == k_AllVehicles)
            {
                vehicleList = m_garage.GetVehiclesList();
            }
            else if (userSelection == k_someVehicles)
            {
                string[] conditionsOptions = Enum.GetNames(typeof(eCondition));

                ConsoleUI.MenuForUser(conditionsOptions);
                int conditionSelection = handleChoice(conditionsOptions.Length);
                eCondition condition = (eCondition) Enum.Parse(typeof(eCondition), conditionSelection.ToString());

                vehicleList = m_garage.GetVehicleList(condition);
            }

            if (vehicleList.Capacity > 0)
            {
                ConsoleUI.MessegeForUser(CreateListForDisplay(vehicleList).ToString());
            }
            else
            {
                ConsoleUI.MessegeForUser("No vehicles to display.");
            }

            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
        }

        private StringBuilder CreateListForDisplay(List<string> i_list)
        {
            StringBuilder newListForDisplay = new StringBuilder();

            foreach (string currentString in i_list)
            {
                newListForDisplay.Append(currentString);
                newListForDisplay.Append("\n");
            }

            return newListForDisplay;
        }

        private void AddVehicleToGarage()
        {
            ConsoleUI.MessegeForUser("Enter vehicle licence plate: ");
            string licence = Console.ReadLine();
            string[] vehiclesMenu = Enum.GetNames(typeof(eVehicleType));

            ConsoleUI.MenuForUser(vehiclesMenu);
            Console.WriteLine("\nChoose a vehicle: ");
            int userChoice = handleChoice(vehiclesMenu.Length);
            eVehicleType vehicleType = (eVehicleType) Enum.Parse(typeof(eVehicleType), userChoice.ToString());

            try
            {
                List<Questioning> vehicleQuestioningsToFill = m_garage.GetInfoToFill(vehicleType, licence);

                FillQuestioningFromUser(vehicleQuestioningsToFill);
                m_garage.InitialNewVehicleInfo(licence);
            }
            catch (ArgumentException ex)
            {
                ConsoleUI.MessegeForUser(ex.Message);
                if (ex.InnerException != null)
                {
                    ConsoleUI.MessegeForUser(ex.InnerException.Message);
                }

                ConsoleUI.MessegeForUser("Information of vehicle with " + licence + "isn't correct. try again.");
                m_garage.RemoveVehicle(licence);
            }
            catch (Exception ex)
            {
                ConsoleUI.MessegeForUser(ex.Message);
                m_garage.ChangeVehicleCondition(licence, eCondition.InTreatment);
            }

            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
        }

        private void ChangeVehicleCondition()
        {
            ConsoleUI.MessegeForUser("Enter vehicle licence plate: ");
            string licence = Console.ReadLine();
            string[] conditionMenu = Enum.GetNames(typeof(eCondition));

            ConsoleUI.MenuForUser(conditionMenu);
            int userChoice = handleChoice(conditionMenu.Length);
            eCondition condition = (eCondition)Enum.Parse(typeof(eCondition), userChoice.ToString());

            try
            {
                m_garage.ChangeVehicleCondition(licence, condition);
                ConsoleUI.MessegeForUser("Vehicle condition has changed to " + condition);
            }
            catch (Exception ex)
            {
                ConsoleUI.MessegeForUser(ex.Message);
            }

            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
        }

        private void DisplayVehicleInfo()
        {
            ConsoleUI.MessegeForUser("Enter vehicle's licence plate: ");
            string licence = Console.ReadLine();

            try
            {
                ConsoleUI.MessegeForUser(m_garage.VehicleInformation(licence));
            }
            catch (Exception ex)
            {
                ConsoleUI.MessegeForUser(ex.Message);
            }

            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
        }

        private void FuelVehicle()
        {
            ConsoleUI.MessegeForUser("Enter vehicle licence plate: ");
            string licence = Console.ReadLine();
            string[] fuelMenu = Enum.GetNames(typeof(eCondition));

            ConsoleUI.MenuForUser(fuelMenu);

            int fuelType = handleChoice(fuelMenu.Length);

            ConsoleUI.MessegeForUser("How much to fill?");
            string userInput = Console.ReadLine();

            float energyToAdd;
            bool optionChosenValidator = float.TryParse(userInput, out energyToAdd);

            while (!optionChosenValidator)
            {
                ConsoleUI.MessegeForUser("Wrong input. How much to fill?");
                userInput = Console.ReadLine();
                optionChosenValidator = float.TryParse(userInput, out energyToAdd);
            }

            try
            {
                m_garage.FuelVehicle(licence, (eFuelType)Enum.Parse(typeof(eFuelType), fuelType.ToString()), energyToAdd);
                ConsoleUI.MessegeForUser("Vehicle has fuled successfully.");
            }
            catch (ArgumentException ex)
            {
                ConsoleUI.MessegeForUser(ex.Message);
            }
            catch (ValueOutOfRangeException ex)
            {
                ConsoleUI.MessegeForUser(ex.Message);
            }
            catch (Exception ex)
            {
                ConsoleUI.MessegeForUser(ex.Message);
            }

            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
        }

        private void ChargeVehicle()
        {
            ConsoleUI.MessegeForUser("Enter vehicle licence plate: ");
            string licence = Console.ReadLine();

            ConsoleUI.MessegeForUser("How much to fill?");
            string userInput = Console.ReadLine();

            float energyToAdd;
            bool optionChosenValidator = float.TryParse(userInput, out energyToAdd);

            while (!optionChosenValidator)
            {
                ConsoleUI.MessegeForUser("Wrong input. How much to Charge?");
                userInput = Console.ReadLine();
                optionChosenValidator = float.TryParse(userInput, out energyToAdd);
            }

            try
            {
                m_garage.ChargeVehicle(licence, energyToAdd);
                ConsoleUI.MessegeForUser("Vehicle has charged successfully.");
            }
            catch (ArgumentException ex)
            {
                ConsoleUI.MessegeForUser(ex.Message);
            }
            catch (ValueOutOfRangeException ex)
            {
                ConsoleUI.MessegeForUser(ex.Message);
            }
            catch (Exception ex)
            {
                ConsoleUI.MessegeForUser(ex.Message);
            }

            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
        }

        private void InflateWheelsToMax()
        {
            ConsoleUI.MessegeForUser("Enter vehicle licence plate: ");
            string licence = Console.ReadLine();

            try
            {
                m_garage.InflateWheelsToMax(licence);
                ConsoleUI.MessegeForUser("Car wheels was filled to max.");
            }
            catch (Exception ex)
            {
                ConsoleUI.MessegeForUser(ex.Message);
            }

            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
        }

        private void FillQuestioningFromUser(List<Questioning> i_questioningToFill)
        {
            Console.Clear();

            foreach (Questioning currentQuestioning in i_questioningToFill)
            {
                Console.Clear();
                ConsoleUI.MessegeForUser(currentQuestioning.Question);

                if (currentQuestioning.AnswerType.IsEnum)
                {
                    string[] enumMenu = Enum.GetNames(currentQuestioning.AnswerType);

                    ConsoleUI.MenuForUser(enumMenu);
                    int userChoice = handleChoice(enumMenu.Length);

                    currentQuestioning.Answer = userChoice.ToString();
                }
                else
                {
                    currentQuestioning.Answer = Console.ReadLine();
                    while (!currentQuestioning.ValidateAnswer())
                    {
                        string messege = "Wrong input. try again.";
                        ConsoleUI.MessegeForUser(messege);
                        ConsoleUI.MessegeForUser(currentQuestioning.Question);

                        currentQuestioning.Answer = Console.ReadLine();
                    }
                }
            }
        }


    }
}
