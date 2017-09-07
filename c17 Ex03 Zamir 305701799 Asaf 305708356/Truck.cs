using System;
using System.Collections.Generic;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        public enum eIndexListQuestioningExtras
        {
            DoesCarryDengerousMaterials = 7,
            MaximumAllowedCarryingWeight
        };

        private const int k_NumberOfWheels = 12;
        private const int k_AirPressureMaxSupport = 34;
        private const float k_MaximumEnergyCapacity = 130;
        private bool m_IsCarryingDangerousSubstances;
        private float m_CurrentCarryingWeight;

        public Truck(Energy i_energy, string i_licenceNumber)
        {
            Energy = i_energy;
            ((Fuel) Energy).FuelType = eFuelType.Soler;
            Wheels = new List<Wheel>(k_NumberOfWheels);

            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                Wheels.Add(new Wheel());
            }

            m_LicenceNumber = i_licenceNumber;

            CreateQuestionings();
        }

        public sealed override void CreateQuestionings()
        {
            base.CreateQuestionings();
            m_Questioning.Add(new Questioning("Does carry dengerous cargo: ", typeof(bool)));
            m_Questioning.Add(new Questioning("current cargo weight: ", typeof(float)));
        }

        public override void InitializeArguments()
        {
            base.InitializeArguments();
            Energy.MaxCapacity = k_MaximumEnergyCapacity;
            m_IsCarryingDangerousSubstances =
                bool.Parse(m_Questioning[(int) eIndexListQuestioningExtras.DoesCarryDengerousMaterials].Answer);
            m_CurrentCarryingWeight =
                float.Parse(m_Questioning[(int) eIndexListQuestioningExtras.MaximumAllowedCarryingWeight].Answer);

            foreach (Wheel currentWheel in Wheels)
            {
                if (float.Parse(m_Questioning[(int) eIndexListQuestioning.WheelMaxAirPressure].Answer)> k_AirPressureMaxSupport)
                {
                    throw new ArgumentException("Wheel maximum pressure is bigger than the truck support!",
                        new ValueOutOfRangeException(0, k_AirPressureMaxSupport));
                }
                else
                {
                    currentWheel.Initialize(m_Questioning[(int) eIndexListQuestioning.WheelsManufecturer].Answer,
                        float.Parse(m_Questioning[(int) eIndexListQuestioning.WheelMaxAirPressure].Answer),
                        float.Parse(m_Questioning[(int) eIndexListQuestioning.WheelCurrentAirPressure].Answer));
                }
            }
        }

        public override string GetInfo()
        {
            string truckInfo = string.Format(
                @"Owner name: {0}
Owner phone number: {1}
Model name: {2}
Licence number: {3}
Status: {4}
Wheels - Manufecturer: {5}, Air pressure: {6}
Engine type: Fuel
Fuel Type: {7}
Current energy: {8} litter
Does carry dengerous cargo: {9}
Cargo weight: {10}",
                m_OwnerName, m_OwnerPhone, m_ModelName, m_LicenceNumber, TreatmentCondition, Wheels[0].Manufacturer,
                Wheels[0].CurrentAirPressure, (Energy as Fuel).FuelType, Energy.CurrentCapacity,
                m_IsCarryingDangerousSubstances, m_CurrentCarryingWeight);

            return truckInfo;
        }
    }
}
