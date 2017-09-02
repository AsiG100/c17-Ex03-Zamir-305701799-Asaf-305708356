namespace Ex03.GarageLogic
{
    class Electricity : Energy
    {
        private float m_TimeLeft;
        private float m_AcummulatedMaxTime;

        public float ChargeBattery(float i_amount)
        {
            //TODO
            return 0f;
        }

        public override string ToString()
        {
            string str = string.Format("Time left for the battery: {0}", m_TimeLeft);
            return str;
        }
    }
}
