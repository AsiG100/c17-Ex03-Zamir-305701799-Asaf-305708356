using System;
using System.Collections.Generic;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        public enum eIndexListQuestioningExtras
        {
            Color = 7,
            NumOfDoors
        };

        private eColor m_Color;
        private eDoors m_numOfDoors;
        private int k_NumberOfWheels = 4;
        private int k_MaximumAirPressure;
        private float k_MaximumEnergyCapacity;

        public Car(Energy i_energy, string i_licenceNumber)
        {
            m_Energy = i_energy;
            m_LicenceNumber = i_licenceNumber;
            m_Wheels = new List<Wheel>(k_NumberOfWheels);

            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                m_Wheels[i] = new Wheel();
            }

            if (m_Energy is Fuel)
            {
                k_MaximumAirPressure = 32;
                k_MaximumEnergyCapacity = 50;
                (m_Energy as Fuel).FuelType = eFuelType.Octan98;
            }
            else if (m_Energy is Electricity)
            {
                k_MaximumAirPressure = 32;
                k_MaximumEnergyCapacity = 2.8f;
            }
        }

        public override void CreateQuestionings()
        {
            base.CreateQuestionings();
            m_Questioning.Add(new Questioning("How many doors: ", typeof(eDoors)));
            m_Questioning.Add(new Questioning("Which car color: ", typeof(eColor)));
        }

        public override void InitializeArguments()
        {
            base.InitializeArguments();
            m_Energy.MaxCapacity = k_MaximumEnergyCapacity;
            m_numOfDoors = (eDoors) Enum.Parse(typeof(eDoors),
                m_Questioning[(int) eIndexListQuestioningExtras.NumOfDoors].Answer);
            m_Color = (eColor) Enum.Parse(typeof(eColor),
                m_Questioning[(int) eIndexListQuestioningExtras.Color].Answer);

            foreach (Wheel currentWheel in m_Wheels)
            {
                if (float.Parse(m_Questioning[(int) eIndexListQuestioning.WheelMaxAirPressure].Answer) >
                    k_MaximumAirPressure)
                {
                    throw new ArgumentException("Wheel maximum pressure is bigger than the motorcycle support");
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
            string carInfo = "";

            if (m_Energy is Fuel)
            {
                carInfo = string.Format(
@"Owner name: {0}
Owner phone number: {1}
Model name: {2}
Licence number: {3}
Status: {4}
Wheels - Manufecturer: {5}, Air pressure: {6}
Engine type: Fuel
Fuel Type: {7}
Current energy: {8} litter
Number of doors: {9}
Color: {10}",
                    m_OwnerName, m_OwnerPhone, m_ModelName, m_LicenceNumber, m_TreatmentCondition, m_Wheels[0].Manufacturer,
                    m_Wheels[0].CurrentAirPressure, ((Fuel) m_Energy).FuelType, m_Energy.CurrentCapacity,
                    m_numOfDoors, m_Color);
            }
            else if (m_Energy is Electricity)
            {
                carInfo = string.Format(
@"Owner name: {0}
Owner phone number: {1}
Model name: {2}
Licence number: {3}
Status: {4}
Wheels - Manufecturer: {5}, Air pressure: {6}
Engine type: Electricity
Fuel Type: {7}
Current energy: {8} litter
Number of doors: {9}
Color: {10}",
                    m_OwnerName, m_OwnerPhone, m_ModelName, m_LicenceNumber, m_TreatmentCondition, m_Wheels[0].Manufacturer,
                    m_Wheels[0].CurrentAirPressure, ((Electricity) m_Energy).FuelType, m_Energy.CurrentCapacity,
                    m_numOfDoors, m_Color);
            }

            return carInfo;
        }
    }
}
