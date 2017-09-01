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
            foreach (TreatedCar car in m_TreatedCars)
            {
                if(car)
            }
        }
    }
}
