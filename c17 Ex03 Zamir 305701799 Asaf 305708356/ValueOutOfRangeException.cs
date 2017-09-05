using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public ValueOutOfRangeException( float i_min, float i_max)
        {
            this.m_MaxValue = i_max;
            this.m_MinValue = i_min;
        }

        public float MaxValue
        { get { return m_MaxValue; } }

        public float MinValue
        { get { return m_MinValue; } }

        public override string Message
        {
            get { return "(try " + m_MinValue + " - " + m_MaxValue + ")."; }
        }
    }
}
