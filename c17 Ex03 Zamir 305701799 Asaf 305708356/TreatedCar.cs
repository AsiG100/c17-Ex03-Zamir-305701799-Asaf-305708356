using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    class TreatedCar
    {
        public string m_OwnerName { get; set; }
        private string m_OwnerPhone { get; set; }
        private eCondition m_TreatmentCondition { get; set; }
        private Vehicle m_Vehicle { get; set; }

        public TreatedCar(string i_Owner, string i_Phone, eCondition i_Condition, 
                                                                Vehicle i_Vehicle)
        {
            this.m_OwnerName = i_Owner;
            this.m_OwnerPhone = i_Phone;
            this.m_TreatmentCondition = i_Condition;
            this.m_Vehicle = i_Vehicle;
        }


    }
}
