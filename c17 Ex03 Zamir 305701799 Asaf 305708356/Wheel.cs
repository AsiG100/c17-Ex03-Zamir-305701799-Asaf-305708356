using System;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_Manufacturer;
        private float m_MaxAirPressure;
        private float m_CurrentAirPressure;

        public void Initialize(string i_manufacturer, float i_maxAirPressure, float i_currentAirPressure)
        {
            if (i_currentAirPressure > i_maxAirPressure)
            {
                throw new ArgumentException("Current air pressure must be less than maximum air pressure",
                    new ValueOutOfRangeException(0, m_MaxAirPressure));
            }
            else
            {
                m_Manufacturer = i_manufacturer;
                m_MaxAirPressure = i_maxAirPressure;
                m_CurrentAirPressure = i_currentAirPressure;
            }
        }

        public void InflateWheel(float i_amount)
        {
            if (i_amount + m_CurrentAirPressure > m_MaxAirPressure)
            {
                throw new ValueOutOfRangeException(0, m_MaxAirPressure - m_CurrentAirPressure);
            }
            else
            {
                m_CurrentAirPressure += i_amount;
            }
        }

        public float MaxAirPressure
        {
            get { return m_MaxAirPressure; }
            set { m_MaxAirPressure = value; }
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set { m_CurrentAirPressure = value; }
        }

        public string Manufacturer
        {
            get { return m_Manufacturer; }
        }
    }
}
