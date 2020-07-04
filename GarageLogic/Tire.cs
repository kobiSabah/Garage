namespace GarageLogic
{
    public class Tire
    {
        private readonly string r_ManufacturerName;
        private readonly float r_MaxAirPressure;
        private readonly ValueOutOfRangeException r_CheckRange;
        private float m_CurrentAirPressure;

        public Tire(string i_ManufacturerName, float i_MaxAirPressure)
        {
            r_ManufacturerName = i_ManufacturerName;
            r_MaxAirPressure = i_MaxAirPressure;
            r_CheckRange = new ValueOutOfRangeException(0, i_MaxAirPressure);
        }

        public void Inflate(float i_AmountOfAir)
        {
            r_CheckRange.ValidateRange(i_AmountOfAir);
            m_CurrentAirPressure += i_AmountOfAir;
        }

        public float MaxPressure
        {
            get
            {
                return r_MaxAirPressure;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }

            set
            {
                r_CheckRange.ValidateRange(value);
                m_CurrentAirPressure = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
@"
==========================================
||           Wheels Details             ||
==========================================
 Manufacture name : {0}                         
 Max air pressure : {1}                         
 Current air pressure: {2}                      
==========================================",
                r_ManufacturerName,
                r_MaxAirPressure,
                m_CurrentAirPressure);
        }
    }
}
