using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    class Fuel : Energy
    {
        private eFuelType m_FuelType;
        private float m_FuelAmount;
        private float m_MaxFuelAmount;

        public float StreamFuel(eFuelType i_type, float i_amount)
        {
            //TODO + throws exception for the amount
            return 0f;
        }

        public eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }
        }

        public override string ToString()
        {
            string str = string.Format("Fuel type: {0}, Amount of fuel: {1}"
                                        , m_FuelType, m_FuelAmount);
            return str;
        }
    }
}
