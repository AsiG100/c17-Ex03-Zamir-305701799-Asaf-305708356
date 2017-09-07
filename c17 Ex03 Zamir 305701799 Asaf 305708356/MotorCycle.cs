using System;
using System.Collections.Generic;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public class MotorCycle : Vehicle
    {
        public enum eIndexListQuestioningExtras 
        {
            LicenceType = 7,
            EnergyCapacity
        };

        private eLicenceType m_LicenceType;
        private int m_EnergyCapacity;
        private const int k_NumberOfWheels = 2;
        private const int k_MaximumAirPressure = 28;
        private float m_MaximumEnergyCapacity;

        public MotorCycle(Energy i_energy, string i_licencePlate)
        {
            Energy = i_energy;
            m_LicenceNumber = i_licencePlate;
            Wheels = new List<Wheel>(k_NumberOfWheels);

            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                Wheels.Add(new Wheel());
            }

            if (Energy is Fuel)
            {
                m_MaximumEnergyCapacity = 5.5f;
                (Energy as Fuel).FuelType = eFuelType.Octan95;
            }
            else
            {
                m_MaximumEnergyCapacity = 1.6f;
            }

            CreateQuestionings();
        }

        public sealed override void CreateQuestionings()
        {
            base.CreateQuestionings();
            m_Questioning.Add(new Questioning("Licence type: ", typeof(eLicenceType)));
            m_Questioning.Add(new Questioning("Energy cc.: ",typeof(int)));
        }

        public override void InitializeArguments()
        {
            base.InitializeArguments();
            Energy.MaxCapacity = m_MaximumEnergyCapacity;
            m_LicenceType = (eLicenceType) Enum.Parse(typeof(eLicenceType),
                m_Questioning[(int) eIndexListQuestioningExtras.LicenceType].Answer);
            m_EnergyCapacity = int.Parse(m_Questioning[(int) eIndexListQuestioningExtras.EnergyCapacity].Answer);

            foreach (Wheel currentWheel in Wheels)
            {
                if (float.Parse(m_Questioning[(int) eIndexListQuestioning.WheelMaxAirPressure].Answer) >
                    k_MaximumAirPressure)
                {
                    throw new ArgumentException("Wheel maximum pressure is bigger than the motorcycle support");
                }
                else
                {
                    currentWheel.Initialize(m_Questioning[(int)eIndexListQuestioning.WheelsManufecturer].Answer,
                        float.Parse(m_Questioning[(int)eIndexListQuestioning.WheelMaxAirPressure].Answer),
                        float.Parse(m_Questioning[(int)eIndexListQuestioning.WheelCurrentAirPressure].Answer));
                }
            }
        }

        public override string GetInfo()
        {
            string motorcycleInfo = "";

            if (Energy is Fuel)
            {
                motorcycleInfo = string.Format(
@"Owner name: {0}
Owner phone number: {1}
Model name: {2}
Licence number: {3}
Status: {4}
Wheels - Manufecturer: {5}, Air pressure: {6}
Engine type: Fuel
Fuel Type: {7}
Current energy: {8} litter
Maximum Engine cc: {9}
Licence type: {10}",
                    m_OwnerName, m_OwnerPhone, m_ModelName, m_LicenceNumber, TreatmentCondition, Wheels[0].Manufacturer,
                    Wheels[0].CurrentAirPressure, (Energy as Fuel).FuelType, Energy.CurrentCapacity,
                    m_EnergyCapacity, m_LicenceType);
            }
            else if (Energy is Electricity)
            {
                motorcycleInfo = string.Format(
@"Owner name: {0}
Owner phone number: {1}
Model name: {2}
Licence number: {3}
Status: {4}
Wheels - Manufecturer: {5}, Air pressure: {6}
Engine type: Electricity
Current energy: {7} litter
Maximum Engine cc: {8}
Licence type: {9}",
                    m_OwnerName, m_OwnerPhone, m_ModelName, m_LicenceNumber, TreatmentCondition, Wheels[0].Manufacturer,
                    Wheels[0].CurrentAirPressure, Energy.CurrentCapacity,
                    m_EnergyCapacity, m_LicenceType);
            }

            return motorcycleInfo;
        }
    }
}
