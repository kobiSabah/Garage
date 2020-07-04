using System.Collections.Generic;

namespace GarageLogic
{
    public static class Factory
    {
        private const float k_MaxCarFuelTankCapacity = 60f;
        private const float k_MaxCarBatteryCapacity = 2.1f;
        private const float k_MaxMotorcycleFuelTankCapacity = 7f;
        private const float k_MaxMotorcycleBatteryCapacity = 1.2f;
        private const float k_MaxTruckFuelTankCapacity = 120f;
        private const float k_MaxCarAirPressure = 32f;
        private const float k_MaxTruckAirPressure = 28f;
        private const float k_MaxMotorcycleAirPressure = 30f;

        public enum eVehicleType
        {
            Car = 1,
            Truck,
            Motorcycle
        }

        public enum eEnergyType
        {
            Fuel = 1,
            Electric
        }

        public static Truck GenerateTruck(string i_ModelName, string i_LicenseNumber, List<Tire> i_Wheels, EnergyStorage i_EnergyStorage, bool i_ContainDangerousMaterials, float i_CargoCapacity, float i_EnergyPercentage)
        {
            return new Truck(i_ContainDangerousMaterials, i_CargoCapacity, i_EnergyStorage, i_ModelName, i_LicenseNumber, i_Wheels, i_EnergyPercentage);
        }

        public static Motorcycle GenerateMotorcycle(string i_ModelName, string i_LicenseNumber, List<Tire> i_Wheels, EnergyStorage i_EnergyStorage, Motorcycle.eLicenseType i_LicenseType, int i_EngineCapacity, float i_EnergyPercentage)
        {
            return new Motorcycle(i_LicenseType, i_EngineCapacity, i_EnergyStorage, i_ModelName, i_LicenseNumber, i_Wheels, i_EnergyPercentage);
        }

        public static Car GenerateCar(
            string i_ModelName,
            string i_LicenseNumber,
            List<Tire> i_Wheels,
            EnergyStorage i_EnergyStorage,
            Car.eColor i_Color,
            byte i_NumberOfDoors,
            float i_EnergyPercentage)
        {
            return new Car(i_Color, i_NumberOfDoors, i_EnergyStorage, i_ModelName, i_LicenseNumber, i_Wheels, i_EnergyPercentage);
        }

        public static List<Tire> GenerateVehicleTire(eVehicleType i_VehicleType, int i_NumberOfTires, string i_ManufacturerName)
        {
            float maxAirPressure = 0;

            switch(i_VehicleType)
            {
                case eVehicleType.Car:
                    maxAirPressure = k_MaxCarAirPressure;
                    break;
                case eVehicleType.Truck:
                    maxAirPressure = k_MaxTruckAirPressure;
                    break;
                case eVehicleType.Motorcycle:
                    maxAirPressure = k_MaxMotorcycleAirPressure;
                    break;
            }

            List<Tire> wheels = new List<Tire>(i_NumberOfTires);
            for(int i = 0; i < i_NumberOfTires; i++)
            {
                wheels.Add(new Tire(i_ManufacturerName, maxAirPressure));
            }

            return wheels;
        }

        public static EnergyStorage GenerateEnergyStorage(eVehicleType i_VehicleType, eEnergyType i_EnergyType)
        {
            EnergyStorage energyStorage = null;

            switch(i_VehicleType)
            {
                case eVehicleType.Truck:
                    energyStorage = new Fuel(k_MaxTruckFuelTankCapacity, Fuel.eFuelType.Soler);
                    break;
                case eVehicleType.Car when i_EnergyType == eEnergyType.Fuel:
                    energyStorage = new Fuel(k_MaxCarFuelTankCapacity, Fuel.eFuelType.Octan96);
                    break;
                case eVehicleType.Car when i_EnergyType == eEnergyType.Electric:
                    energyStorage = new Electric(k_MaxCarBatteryCapacity);
                    break;
                case eVehicleType.Motorcycle when i_EnergyType == eEnergyType.Fuel:
                    energyStorage = new Fuel(k_MaxMotorcycleFuelTankCapacity, Fuel.eFuelType.Octan95);
                    break;
                case eVehicleType.Motorcycle when i_EnergyType == eEnergyType.Electric:
                    energyStorage = new Electric(k_MaxMotorcycleBatteryCapacity);
                    break;
            }

            return energyStorage;
        }
    }
}
