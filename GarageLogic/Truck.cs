using System.Collections.Generic;

namespace GarageLogic
{
    public class Truck : Vehicle
    {
        private readonly bool r_ContainDangerousMaterials;
        private readonly float r_CargoCapacity;

        public Truck(bool i_ContainDangerousMaterials, float i_CargoCapacity, EnergyStorage i_FuelTank, string i_ModelName, string i_LicenseNumber, List<Tire> i_Wheels, float i_EnergyPercentage)
        : base(i_ModelName, i_LicenseNumber, i_Wheels, i_FuelTank, i_EnergyPercentage)
        {
            r_ContainDangerousMaterials = i_ContainDangerousMaterials;
            r_CargoCapacity = i_CargoCapacity;
        }

        public override void FillEnergyStorage(float i_Amount, Fuel.eFuelType i_FuelType)
        {
            EnergyStorage.Fill(i_Amount, i_FuelType);
            m_EnergyPercentage = r_EnergyStorage.CalculatePercentage();
        }

        public override string ToString()
        {
            return string.Format(
                @"
Model number : {0}
License number: {1}
Contain dangerous materials : {2}
Cargo capacity : {3}
Energy percentage :{4}%
{5}
Number of wheels : {6}
{7}",
                r_ModelName,
                r_LicenseNumber,
                r_ContainDangerousMaterials,
                r_CargoCapacity,
                m_EnergyPercentage,
                r_EnergyStorage,
                r_Wheels.Count,
                r_Wheels[0]);
        }
    }
}
