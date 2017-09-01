using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    class TreatedCar
    {
        private string m_OwnerName;
        private string m_OwnerPhone;
        private eCondition m_TreatmentCondition;
        private Vehicle m_Vehicle;

        public TreatedCar(string i_Owner, string i_Phone, eCondition i_Condition, 
                                                                Vehicle i_Vehicle)
        {
            this.m_OwnerName = i_Owner;
            this.m_OwnerPhone = i_Phone;
            this.m_TreatmentCondition = i_Condition;
            this.m_Vehicle = i_Vehicle;
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }
        }

        public eCondition TreatmentCondition
        {
            get
            {
                return m_TreatmentCondition;
            }
            set
            {
                m_TreatmentCondition = value;
            }
        }

    }
}
