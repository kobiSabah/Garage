using System.Collections.Generic;

namespace GarageLogic
{
    public abstract class Vehicle
    {
        protected readonly string r_ModelName;
        protected readonly string r_LicenseNumber;
        protected readonly EnergyStorage r_EnergyStorage;
        protected readonly List<Tire> r_Wheels;
        protected float m_EnergyPercentage;

        protected Vehicle(string i_ModelName, string i_LicenseNumber, List<Tire> i_Wheels, EnergyStorage i_EnergyStorage, float i_EnergyPercentage)
        {
            r_ModelName = i_ModelName;
            r_LicenseNumber = i_LicenseNumber;
            r_Wheels = i_Wheels;
            r_EnergyStorage = i_EnergyStorage;
            m_EnergyPercentage = i_EnergyPercentage;
            EnergyStorage.CalculateCurrentAmount(m_EnergyPercentage);
        }

        public virtual void FillEnergyStorage(float i_Amount)
        {
        }

        public virtual void FillEnergyStorage(float i_Amount, Fuel.eFuelType i_FuelType)
        {
        }

        public string LicenseNumber
        {
            get
            {
                return r_LicenseNumber;
            }
        }

        public List<Tire> Wheels
        {
            get
            {
                return r_Wheels;
            }
        }

        public EnergyStorage EnergyStorage
        {
            get
            {
                return r_EnergyStorage;
            }
        }
    }
}
