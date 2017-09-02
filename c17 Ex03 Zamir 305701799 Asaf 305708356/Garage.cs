using System.Collections.Generic;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    class Garage
    {
        private List<TreatedCar> m_TreatedCars;

        public Garage()
        {
            this.m_TreatedCars = new List<TreatedCar>();
        }

        /*  Method gets 2 strings and a vehicle object representing owner name, 
         *  his phone and car details.
         *  it checks if the car in the garage
         *      if yes, it changes it's condition to 'In treatment'
         *      if no, it adds it to garage's car list.
         *  The method returns string with confirmation messege
         */
        public string AddVehicle(string i_owner, string i_Phone, Vehicle i_Vehicle)
        {
            string messege = "The vehicle was added to garage cars list";

            foreach (TreatedCar car in m_TreatedCars)
            {
                if (car.Vehicle.LicenceNumber == i_Vehicle.LicenceNumber)
                {
                    messege = string.Format("The vehicle with the following licence number -" +
                                                   "{0}, is already in the garage.\n" +
                                                   "It's condition was modified to {1}",
                                        i_Vehicle.LicenceNumber, eCondition.InTreatment);
                    car.TreatmentCondition = eCondition.InTreatment;
                    break;
                }
            }

            TreatedCar newCar = new TreatedCar(i_owner, i_Phone, eCondition.InTreatment, i_Vehicle);
            m_TreatedCars.Add(newCar);

            return messege;
        }

        /*  Method gets enum with some condition.
         *  It checks in treated cars list for all cars with this condition
         *  and adds their licnce number to a new list.
         *  The method returns the new filtered list.
         */
        public List<string> FindLicenceNumbers(eCondition i_condition)
        {
            List<string> licenceNumbers = new List<string>();
            foreach(TreatedCar car in m_TreatedCars)
            {
                if(car.TreatmentCondition==i_condition)
                {
                    licenceNumbers.Add(car.Vehicle.LicenceNumber);
                }
            }

            return licenceNumbers;
        }

        /*  Method creats a list of car's licence numbers.
         *  It adds all licence numbers of cars in the garage to this list and returns it.
         */
        public List<string> FindLicenceNumbers()
        {
            List<string> licenceNumbers = new List<string>();
            foreach (TreatedCar car in m_TreatedCars)
            {
                licenceNumbers.Add(car.Vehicle.LicenceNumber);
            }

            return licenceNumbers;
        }

        /*  Method gets a string and an enum representing licence of specific car and a condition.
         *  If this licence number appears in the list of cars in the garage
         *  it changes the condition of this car to the given one and returns true.
         *  Else it returns false
         */
        public bool ChangeCondition(string i_LicenceNumber, eCondition i_Condition)
        {
            bool isFound = false;

            foreach(TreatedCar car in m_TreatedCars)
            {
                if(car.Vehicle.LicenceNumber==i_LicenceNumber)
                {
                    car.TreatmentCondition = i_Condition;
                    isFound = true;
                    break;
                }
            }

            return isFound;
        }

        /*  Method gets a string  representing licence of specific car.
         *  If this licence number appears in the list of cars in the garage
         *      it loops through all wheel objects of cars and
         *      changes their current air pressure to maximum and returns true.
         *  Else it returns false.
         */
        public bool InflateWheelsToMax( string i_LicenceNumber)
        {
            bool isFound = false;

            foreach (TreatedCar car in m_TreatedCars)
            {
                if(car.Vehicle.LicenceNumber==i_LicenceNumber)
                {
                    foreach(Wheel wheel in car.Vehicle.Wheels)
                    {
                        wheel.CurrentAirPressure = wheel.MaxAirPressure;
                        isFound = true;
                    }
                }
            }

            return isFound;
        }

        /*  Method gets a string  representing licence of specific car.
         *  If this licence number appears in the list of cars in the garage
         *  it verifies that the fuel type is similar to the one sent as 
         *  a parameter and fill up the amount that was requested and returns true.
         *  Else it returns false.
         */
        public bool FuelVehicle(string i_LicenceNumber, eFuelType i_FuelType
                                , float i_Amount)
        {
            bool isFound = false;

            foreach (TreatedCar car in m_TreatedCars)
            {
                if(car.Vehicle.LicenceNumber==i_LicenceNumber)
                {
                    if(car.Vehicle.EnergyType is Fuel)
                    {
                        Fuel fuel = (Fuel)car.Vehicle.EnergyType;
                        if(fuel.FuelType==i_FuelType)
                        {
                            fuel.StreamFuel(i_FuelType, i_Amount);
                            isFound = true;
                        }
                    }
                    break;
                }
            }

            return isFound;
        }

        /*  Method gets a string  representing licence of specific car.
         *  If this licence number appears in the list of cars in the garage
         *  it verifies that the fuel type is similar to the one sent as 
         *  a parameter and fill up the amount that was requested and returns true.
         *  Else it returns false.
         */
        public bool ChargeVehicle(string i_LicenceNumber, float i_Amount)
        {
            bool isFound = false;

            foreach (TreatedCar car in m_TreatedCars)
            {
                if (car.Vehicle.LicenceNumber == i_LicenceNumber)
                {
                    if (car.Vehicle.EnergyType is Electricity)
                    {
                        Electricity electricity = (Electricity)car.Vehicle.EnergyType;
                        electricity.ChargeBattery(i_Amount);
                        isFound = true;
                    }
                    break;
                }
            }

            return isFound;
        }

        /*  Method gets a string  representing licence of specific car.
         *  If this licence number appears in the list of cars in the garage
         *  it displays it's full details.
         *  Else it returns 'The vehicle wasn't found'.
         */
        public string DisplayVehicleDetails(string i_LicenceNumber)
        {
            string str = "The vehicle wasn't found";

            foreach(TreatedCar car in m_TreatedCars)
            {
                if(car.Vehicle.LicenceNumber == i_LicenceNumber)
                {
                    str = car.ToString();
                }
            }

            return str;
        }

    }

}
