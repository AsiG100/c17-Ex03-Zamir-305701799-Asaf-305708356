using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {
        
        public static Vehicle CreateVehicle(eVehicleType i_typeOfVehicleToCreate, string i_licensePlate)
        {
            Vehicle newVehicle;

            switch (i_typeOfVehicleToCreate)
            {
                case eVehicleType.RegularMotorCycle:
                {
                    newVehicle = new MotorCycle(new Fuel(), i_licensePlate);
                    break;
                }
                case eVehicleType.ElectricMotorCycle:
                {
                    newVehicle = new MotorCycle(new Electricity(), i_licensePlate);
                    break;
                }
                case eVehicleType.RegularCar:
                {
                    newVehicle = new Car(new Fuel(), i_licensePlate);
                    break;
                }
                case eVehicleType.ElectricCar:
                {
                    newVehicle = new Car(new Electricity(), i_licensePlate);
                    break;
                }
                case eVehicleType.Truck:
                {
                    newVehicle = new Truck(new Fuel(), i_licensePlate);
                    break;
                }
                default:
                {
                    newVehicle = null;
                    break;
                }
            }

            return newVehicle;
        }
    }
}
