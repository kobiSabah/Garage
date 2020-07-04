using System.Collections.Generic;

namespace GarageLogic
{
    public class Car : Vehicle
    {
        private readonly eColor r_Color;
        private readonly byte r_NumberOfDoors;

        public enum eColor
        {
            Red = 1,
            Black,
            White,
            Silver
        }

        public Car(eColor i_Color, byte i_NumberOfDoors, EnergyStorage i_EnergyStorage, string i_ModelName, string i_LicenseNumber, List<Tire> i_Wheels, float i_EnergyPercentage)
        : base(i_ModelName, i_LicenseNumber, i_Wheels, i_EnergyStorage, i_EnergyPercentage)
        {
            r_Color = i_Color;
            r_NumberOfDoors = i_NumberOfDoors;
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
license number: {1}
Color : {2}
Number of doors : {3}
Energy percentage :{4}%
{5}
Number of Wheels : {6}
{7}
",
r_ModelName, 
r_LicenseNumber,
r_Color,
r_NumberOfDoors,
m_EnergyPercentage,
r_EnergyStorage,
r_Wheels.Count,
r_Wheels[0]);
        }
    }
}
