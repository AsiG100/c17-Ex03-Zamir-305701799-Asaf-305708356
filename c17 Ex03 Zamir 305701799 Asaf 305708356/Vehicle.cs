using System.Collections.Generic;

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

        public Energy EnergyType
        {
            get
            {
                return m_EnergyType;
            }
        }

        public override string ToString()
        {
            string str = string.Format("Model name: {0}, Licence number: {1}, Energy precentage: {2}"
                                        , m_ModelName, m_LicenceNumber, m_EnergyPrecentage);
            str += "Wheels:";
            foreach (Wheel wheel in m_Wheels)
            {
                str += "\n " + wheel.ToString();
            }
            str += "Energy type:\n " + m_EnergyType.ToString(); ;

            return str;
        }
    }
}
