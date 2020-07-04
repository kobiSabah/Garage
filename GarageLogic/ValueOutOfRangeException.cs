using System;

namespace GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private readonly float r_MaxValue;
        private readonly float r_MinValue;
        private string m_Message;

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
        {
            r_MaxValue = i_MaxValue;
            r_MinValue = i_MinValue;
        }

        public override string Message
        {
            get
            {
                return m_Message;
            }
        }

        public ValueOutOfRangeException(string i_Message)
        {
            m_Message = i_Message;
        }

        public void ValidateRange(float i_Amount)
        {
            if(i_Amount < r_MinValue || i_Amount > r_MaxValue)
            {
                m_Message = string.Format("Error: Value out of range.The number should be between {0} - {1}", r_MinValue, r_MaxValue);
                throw this;
            }
        }
    }
}