using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Vehicle
    {
        private string m_ModelName;
        private string m_LicenceNumber;
        private float m_EnergyPrecentage;
        private List<Wheel> m_Wheels;
        private Energy m_EnergyType;

        public string LicenceNumber
        {
            get
            {
                return m_LicenceNumber;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }
        }
    }
}
