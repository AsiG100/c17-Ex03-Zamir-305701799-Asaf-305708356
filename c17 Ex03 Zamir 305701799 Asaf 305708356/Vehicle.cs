using System.Collections.Generic;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected string m_ModelName;
        protected string m_LicenceNumber;
        protected List<Questioning> m_Questioning;
        protected List<Wheel> m_Wheels;
        protected Energy m_Energy;
        protected string m_OwnerName;
        protected string m_OwnerPhone;
        protected eCondition m_TreatmentCondition;

        public virtual void CreateQuestionings()
        {
            m_Questioning.Add(new Questioning("Enter the owner's name: ", typeof(string)));
            m_Questioning.Add(new Questioning("Enter the owner's phone number: ", typeof(int)));
            m_Questioning.Add(new Questioning("Enter the vehicle's model name: ", typeof(string)));
            m_Questioning.Add(new Questioning("Enter the vehicle's current energy: ", typeof(float)));
            m_Questioning.Add(new Questioning("Enter the wheels current air pressure: ", typeof(float)));
            m_Questioning.Add(new Questioning("Enter the wheels maximum air pressure: ", typeof(string)));
            m_Questioning.Add(new Questioning("Enter the wheels manufecturer name: ", typeof(string)));
        }

        public Vehicle()
        {
            m_TreatmentCondition = eCondition.InTreatment;
            m_Questioning = new List<Questioning>();
        }

        public eCondition TreatmentCondition
        {
            get { return m_TreatmentCondition; }
            set { m_TreatmentCondition = value; }
        }

        public List<Wheel> Wheels
        {
            get { return m_Wheels; }
            set { m_Wheels = value; }
        }

        public Energy Energy
        {
            get { return m_Energy; }
            set { m_Energy = value; }
        }

        public virtual void InflateWheels(float i_airToAdd)
        {
            foreach (Wheel currentWheel in m_Wheels)
            {
                currentWheel.InflateWheel(i_airToAdd);
            }
        }

        public virtual void FillWithEnergy(float i_energyToFill)
        {
            if (i_energyToFill + m_Energy.CurrentCapacity > m_Energy.MaxCapacity)
            {
                throw new ValueOutOfRangeException(0, m_Energy.MaxCapacity - m_Energy.CurrentCapacity);
            }
            else
            {
                m_Energy.CurrentCapacity += i_energyToFill;
            }
        }

        public List<Questioning> Questionings
        {
            get { return m_Questioning; }
        }

        public override string ToString()
        {
            return m_LicenceNumber;
        }

        public virtual void InitializeArguments()
        {
            m_OwnerName = m_Questioning[(int) eIndexListQuestioning.OwnerName].Answer;
            m_OwnerPhone = m_Questioning[(int) eIndexListQuestioning.OwnerPhone].Answer;
            m_ModelName = m_Questioning[(int) eIndexListQuestioning.VehicleModelName].Answer;
            m_Energy.CurrentCapacity = float.Parse(m_Questioning[(int) eIndexListQuestioning.CurrentEnergyCapacity].Answer);
        }

        public abstract string GetInfo();
    }
}
