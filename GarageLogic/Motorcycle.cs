using System.Collections.Generic;

namespace GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private readonly eLicenseType r_LicenseType;
        private readonly int r_EngineCapacity;

        public enum eLicenseType
        {
            A,
            A1,
            AA,
            B
        }

        public Motorcycle(eLicenseType i_LicenseType, int i_EngineCapacity, EnergyStorage i_EnergyStorage, string i_ModelName, string i_LicenseNumber, List<Tire> i_Wheels, float i_EnergyPercentage) 
            : base(i_ModelName, i_LicenseNumber, i_Wheels, i_EnergyStorage, i_EnergyPercentage)
        {
            r_LicenseType = i_LicenseType;
            r_EngineCapacity = i_EngineCapacity;
        }

        public override void FillEnergyStorage(float i_Amount)
        {
            EnergyStorage.Fill(i_Amount);
            m_EnergyPercentage = r_EnergyStorage.CalculatePercentage();
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
License type : {2}
Engine capacity : {3}
Energy percentage :{4}%
{5}
Number of wheels:{6}
{7}
",
                r_ModelName,
                r_LicenseNumber,
                r_LicenseType,
                r_EngineCapacity,
                m_EnergyPercentage,
                r_EnergyStorage,
                r_Wheels.Count,
                r_Wheels[0]);
        }
    }
}
