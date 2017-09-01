namespace Ex03.GarageLogic
{
    class Wheel
    {
        private string m_Manufacturer;
        private float m_MaxAirPressure;
        private float m_CurrentAirPressure;

        public float InflateWheel(float i_amount)
        {
            //TODO
            return 0f;
        }

        public float MaxAirPressure
        {
            get
            {
                return m_MaxAirPressure;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
            set
            {
                m_CurrentAirPressure = value;
            }
        }

    }
}
