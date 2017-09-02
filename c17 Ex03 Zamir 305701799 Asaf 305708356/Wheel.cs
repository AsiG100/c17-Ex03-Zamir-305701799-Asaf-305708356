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

        public override string ToString()
        {
            string str = string.Format("Manufacturer: {0}, Current air pressure: {1}"
                                        , m_Manufacturer, m_CurrentAirPressure);
            return str;
        }

    }
}
