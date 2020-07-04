namespace GarageLogic
{
    public class EnergyStorage
    {
        private readonly float r_MaxCapacity;
        private readonly ValueOutOfRangeException r_CheckRange;
        private float m_EnergyRemain;

        protected EnergyStorage(float i_MaxCapacity)
        {
            r_MaxCapacity = i_MaxCapacity;
            r_CheckRange = new ValueOutOfRangeException(0, i_MaxCapacity);
        }

        protected float MaxCapacity
        {
            get
            {
                return r_MaxCapacity;
            }
        }

        protected float EnergyRemain
        {
            get
            {
                return m_EnergyRemain;
            }

            set
            {
                r_CheckRange.ValidateRange(value);
                m_EnergyRemain = value;
            }
        }

        public virtual void Fill(float i_Amount)
        {
        }

        public virtual void Fill(float i_Amount, Fuel.eFuelType i_FuelType)
        {
        }

        public float CalculatePercentage()
        {
            return 100 * m_EnergyRemain / r_MaxCapacity;
        }

        public void CalculateCurrentAmount(float i_EnergyPercentage)
        {
            m_EnergyRemain = i_EnergyPercentage * r_MaxCapacity / 100;
        }
    }
}
