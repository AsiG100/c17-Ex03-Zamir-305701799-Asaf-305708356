using System.Collections.Generic;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected string m_ModelName;
        protected string m_LicenceNumber;
        protected List<Questioning> m_Questioning;
        protected string m_OwnerName;
        protected string m_OwnerPhone;

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
            TreatmentCondition = eCondition.InTreatment;
            m_Questioning = new List<Questioning>();
        }

        public eCondition TreatmentCondition { get; set; }

        public List<Wheel> Wheels { get; set; }

        public Energy Energy { get; set; }

        public virtual void InflateWheels(float i_airToAdd)
        {
            foreach (Wheel currentWheel in Wheels)
            {
                currentWheel.InflateWheel(i_airToAdd);
            }
        }

        public virtual void FillWithEnergy(float i_energyToFill)
        {
            if (i_energyToFill + Energy.CurrentCapacity > Energy.MaxCapacity)
            {
                throw new ValueOutOfRangeException(0, Energy.MaxCapacity - Energy.CurrentCapacity);
            }
            else
            {
                Energy.CurrentCapacity += i_energyToFill;
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
            Energy.CurrentCapacity = float.Parse(m_Questioning[(int) eIndexListQuestioning.CurrentEnergyCapacity].Answer);
        }

        public abstract string GetInfo();
    }
}
