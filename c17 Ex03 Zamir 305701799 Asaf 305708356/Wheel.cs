using System;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_Manufacturer;

        public void Initialize(string i_manufacturer, float i_maxAirPressure, float i_currentAirPressure)
        {
            if (i_currentAirPressure > i_maxAirPressure)
            {
                throw new ArgumentException("Current air pressure must be less than maximum air pressure",
                    new ValueOutOfRangeException(0, MaxAirPressure));
            }

            m_Manufacturer = i_manufacturer;
            MaxAirPressure = i_maxAirPressure;
            CurrentAirPressure = i_currentAirPressure;
        }

        public void InflateWheel(float i_amount)
        {
            if (i_amount + CurrentAirPressure > MaxAirPressure)
            {
                throw new ValueOutOfRangeException(0, MaxAirPressure - CurrentAirPressure);
            }
            else
            {
                CurrentAirPressure += i_amount;
            }
        }

        public float MaxAirPressure { get; set; }

        public float CurrentAirPressure { get; set; }

        public string Manufacturer
        {
            get { return m_Manufacturer; }
        }
    }
}
