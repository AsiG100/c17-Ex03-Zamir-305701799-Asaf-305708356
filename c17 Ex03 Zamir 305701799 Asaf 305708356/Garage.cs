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

        //add a new vehicle to the list or edit its condition if it exists
        public string AddVehicle(string i_owner, string i_Phone, Vehicle i_Vehicle)
        {
            string messege = "The vehicle has added";

            foreach (TreatedCar car in m_TreatedCars)
            {
                if (car.Vehicle.LicenceNumber == i_Vehicle.LicenceNumber)
                {
                    messege = string.Format("The vehicle withe the licence number " +
                                                   "of {0} is already in the garage.\n" +
                                                   "the condition has modified to {1}",
                                        i_Vehicle.LicenceNumber, eCondition.InTreatment);
                    car.TreatmentCondition = eCondition.InTreatment;
                    break;
                }
            }

            TreatedCar newCar = new TreatedCar(i_owner, i_Phone, eCondition.InTreatment, i_Vehicle);
            m_TreatedCars.Add(newCar);

            return messege;

        }

        //find all lincence numbers with the condition sent 
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

        //find all licence numbers
        public List<string> FindLicenceNumbers()
        {
            List<string> licenceNumbers = new List<string>();
            foreach (TreatedCar car in m_TreatedCars)
            {
                licenceNumbers.Add(car.Vehicle.LicenceNumber);
            }

            return licenceNumbers;
        }

        //change the condition of the treatment
        public void ChangeCondition(string i_LicenceNumber, eCondition i_Condition)
        {
            foreach(TreatedCar car in m_TreatedCars)
            {
                if(car.Vehicle.LicenceNumber==i_LicenceNumber)
                {
                    car.TreatmentCondition = i_Condition;
                    break;
                }
            }
        }

        //inflate the air in the wheels of the vehicle to the max
        public void InflateWheelsToMax( string i_LicenceNumber)
        {
            foreach(TreatedCar car in m_TreatedCars)
            {
                if(car.Vehicle.LicenceNumber==i_LicenceNumber)
                {
                    foreach(Wheel wheel in car.Vehicle.Wheels)
                    {
                        wheel.CurrentAirPressure = wheel.MaxAirPressure;
                    }
                }
            }
        }

    }

}
