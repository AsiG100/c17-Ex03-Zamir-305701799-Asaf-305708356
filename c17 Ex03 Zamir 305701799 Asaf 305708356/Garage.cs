using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public string AddVehicle(string i_owner, string i_Phone, Vehicle i_Vehicle)
        {
            string messege = "The vehicle has added";

            foreach (TreatedCar car in m_TreatedCars)
            {
                if (car.m_Vehicle.m_LicenceNumber == i_Vehicle.m_LicenceNumber)
                {
                    messege = string.Format("The vehicle withe the licence number " +
                                                   "of {0} is already in the garage.\n" +
                                                   "the condition has modified to {1}",
                                        i_Vehicle.m_LicenceNumber, eCondition.InTreatment);
                    car.m_TreatmentCondition = eCondition.InTreatment;
                }
            }

            TreatedCar newCar = new TreatedCar(i_owner, i_Phone, eCondition.InTreatment, i_Vehicle);
            m_TreatedCars.Add(newCar);

            return messege;

        }
    }
}
