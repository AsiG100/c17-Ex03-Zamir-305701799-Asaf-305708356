using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
        private int k_MaximumAirPressure;
        private float k_MaximumEnergyCapacity;

        public MotorCycle(Energy i_energy, string i_licencePlate)
        {
            m_Energy = i_energy;
            m_LicenceNumber = i_licencePlate;
            m_Wheels = new List<Wheel>(k_NumberOfWheels);

            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                m_Wheels.Add(new Wheel());
            }

            if (m_Energy is Fuel)
            {
                k_MaximumAirPressure = 28;
                k_MaximumEnergyCapacity = 5.5f;
                (m_Energy as Fuel).FuelType = eFuelType.Octan95;
            }
            else
            {
                k_MaximumAirPressure = 28;
                k_MaximumEnergyCapacity = 1.6f;
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
            m_Energy.MaxCapacity = k_MaximumEnergyCapacity;
            m_LicenceType = (eLicenceType) Enum.Parse(typeof(eLicenceType),
                m_Questioning[(int) eIndexListQuestioningExtras.LicenceType].Answer);
            m_EnergyCapacity = int.Parse(m_Questioning[(int) eIndexListQuestioningExtras.EnergyCapacity].Answer);

            foreach (Wheel currentWheel in m_Wheels)
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

        [SuppressMessage("ReSharper", "PossibleInvalidCastException")]
        public override string GetInfo()
        {
            string motorcycleInfo = "";

            if (m_Energy is Fuel)
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
Engine cc: {9}
Licence type: {10}",
                    m_OwnerName, m_OwnerPhone, m_ModelName, m_LicenceNumber, m_TreatmentCondition, m_Wheels[0].Manufacturer,
                    m_Wheels[0].CurrentAirPressure, (m_Energy as Fuel).FuelType, m_Energy.CurrentCapacity,
                    m_EnergyCapacity, m_LicenceType);
            }
            else if (m_Energy is Electricity)
            {
                motorcycleInfo = string.Format(
@"Owner name: {0}
Owner phone number: {1}
Model name: {2}
Licence number: {3}
Status: {4}
Wheels - Manufecturer: {5}, Air pressure: {6}
Engine type: Electricity
Fuel Type: {7}
Current energy: {8} litter
Engine cc: {9}
Licence type: {10}",
                    m_OwnerName, m_OwnerPhone, m_ModelName, m_LicenceNumber, m_TreatmentCondition, m_Wheels[0].Manufacturer,
                    m_Wheels[0].CurrentAirPressure, ((Fuel) m_Energy).FuelType, m_Energy.CurrentCapacity,
                    m_EnergyCapacity, m_LicenceType);
            }

            return motorcycleInfo;
        }
    }
}
