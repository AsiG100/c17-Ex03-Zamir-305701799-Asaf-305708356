using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, Vehicle> m_TreatedVehicles = new Dictionary<string, Vehicle>();

        public void InitializeNewVehicle(string i_licence)
        {
            m_TreatedVehicles[i_licence].InitializeArguments();
        }

        public List<Questioning> GetInfoToFill(eVehicleType i_VehicleType, string i_licence)
        {
            List<Questioning> questionings = new List<Questioning>();

            if (!m_TreatedVehicles.ContainsKey(i_licence))
            {
                Vehicle newVehicle = VehicleFactory.CreateVehicle(i_VehicleType, i_licence);
                m_TreatedVehicles.Add(i_licence, newVehicle);
                questionings = newVehicle.Questionings;
            }
            else
            {
                throw new Exception("Vehicle with licence plate " + i_licence +
                                    " already exists.\n" +
                                    "Vehicle status will change to 'in treatment'.");
            }

            return questionings;
        }

        public void InitialNewVehicleInfo(string i_licence)
        {
            if (m_TreatedVehicles.ContainsKey(i_licence))
            {
                m_TreatedVehicles[i_licence].InitializeArguments();
            }
            else
            {
                throw new Exception("Vehicle doesn't exists!");
            }
        }

        public void ChangeVehicleCondition(string i_licence, eCondition i_newCondition)
        {
            if (m_TreatedVehicles.ContainsKey(i_licence))
            {
                m_TreatedVehicles[i_licence].TreatmentCondition = i_newCondition;
            }
            else
            {
                throw new Exception("Vehicle doesn't exists!");
            }
        }

        public string VehicleInformation(string i_licence)
        {
            StringBuilder vehicleInformation = new StringBuilder();

            if (m_TreatedVehicles.ContainsKey(i_licence))
            {
                vehicleInformation.Append("Licence plate: ");
                vehicleInformation.Append(i_licence);
                vehicleInformation.Append("\n");
                vehicleInformation.Append("All information: ");
                vehicleInformation.Append("\n");
                vehicleInformation.Append(m_TreatedVehicles[i_licence].GetInfo());
            }
            else
            {
                throw new Exception("Vehicle doesn't exists!");
            }

            return vehicleInformation.ToString();
        }

        public List<string> GetVehiclesList()
        {
            List<string> vehicleList = new List<string>();

            foreach (KeyValuePair<string, Vehicle> currentVehicle in m_TreatedVehicles)
            {
                vehicleList.Add(currentVehicle.Value.ToString());
            }

            return vehicleList;
        }

        public List<string> GetVehicleList(eCondition i_condition)
        {
            List<string> vehicleList = new List<string>();

            foreach (KeyValuePair<string, Vehicle> currentVehicle in m_TreatedVehicles)
            {
                if (currentVehicle.Value.TreatmentCondition == i_condition)
                {
                    vehicleList.Add(currentVehicle.Value.ToString());
                }
            }

            return vehicleList;
        }

        public void FuelVehicle(string i_licence, eFuelType i_fuelType, float i_quantityToAdd)
        {
            if (m_TreatedVehicles != null && !m_TreatedVehicles.ContainsKey(i_licence))
            {
                throw new Exception("Vehicle doesn't exists!");
            }
            if (m_TreatedVehicles != null && m_TreatedVehicles[i_licence].Energy is Electricity)
            {
                throw new ArgumentException("Vehicle works on electricity and not on fuel!");
            }
            if (m_TreatedVehicles != null && m_TreatedVehicles[i_licence].Energy is Fuel)
            {
                throw new ArgumentException("Fuel type doesn't matchQ");
            }

            try
            {
                if (m_TreatedVehicles != null)
                {
                    m_TreatedVehicles[i_licence].FillWithEnergy(i_quantityToAdd);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ChargeVehicle(string i_licence, float i_quantityToAdd)
        {
            if (m_TreatedVehicles != null && !m_TreatedVehicles.ContainsKey(i_licence))
            {
                throw new Exception("Vehicle doesn't exists!");
            }
            if (m_TreatedVehicles != null && m_TreatedVehicles[i_licence].Energy is Fuel)
            {
                throw new ArgumentException("Vehicle works on fuel and not on electricity!");
            }

            try
            {
                if (m_TreatedVehicles != null)
                {
                    m_TreatedVehicles[i_licence].FillWithEnergy(i_quantityToAdd);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InflateWheelsToMax(string i_licence)
        {
            if (m_TreatedVehicles.ContainsKey(i_licence))
            {
                m_TreatedVehicles[i_licence].InflateWheels(m_TreatedVehicles[i_licence].Wheels[0].MaxAirPressure -
                                                           m_TreatedVehicles[i_licence].Wheels[0].CurrentAirPressure);
            }
            else
            {
                throw new Exception("Vehicle doesn't exists!");
            }
        }

        public void RemoveVehicle(string i_licence)
        {
            m_TreatedVehicles.Remove(i_licence);
        }
    }
}