using System;

namespace GarageLogic
{
    public class Fuel : EnergyStorage
    {
        private readonly eFuelType r_FuelType;

        public enum eFuelType
        {
            Soler = 1,
            Octan95,
            Octan96,
            Octan98
        }

        public Fuel(float i_MaxCapacityFuelTank, eFuelType i_FuelType)
            : base(i_MaxCapacityFuelTank)
        {
            r_FuelType = i_FuelType;
        }

        public override void Fill(float i_Amount, eFuelType i_FuelType)
        {
            if(i_FuelType != r_FuelType)
            {
                throw new ArgumentException("Fuel type was not match");
            }

            if (MaxCapacity < EnergyRemain + i_Amount)
            {
                string msg = string.Format(
                    "Error: You are trying to fill the fuel tank with too much fuel{0} You can fill the fuel tank with {1} liters",
                    Environment.NewLine,
                    MaxCapacity - EnergyRemain);
                throw new ValueOutOfRangeException(msg);
            }

            EnergyRemain += i_Amount;
            CalculatePercentage();
        }

        public override string ToString()
        {
            return string.Format(
                @"
===========================
|| Energy storage details||
===========================
Energy Type : Fuel
Fuel Type : {0}
Fuel tank capacity : {1} liter
Current capacity : {2} liter
===========================",
                r_FuelType,
                MaxCapacity,
                EnergyRemain);
        }
    }
}
