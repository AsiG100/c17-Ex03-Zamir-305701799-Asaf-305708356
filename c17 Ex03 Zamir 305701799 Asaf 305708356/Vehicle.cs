using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Vehicle
    {
        public string m_ModelName { get; set; }
        public string m_LicenceNumber { get; set; }
        public float m_EnergyPrecentage { get; set; }
        public List<Wheel> m_Wheels { get; set; }
        public Energy m_EnergyType { get; set; }
    }
}
