using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public class Electricity : Energy
    {
        private eFuelType m_FuelType;

        public eFuelType FuelType
        {
            get { return m_FuelType; }
            set { m_FuelType = value; }
        }
    }
}
