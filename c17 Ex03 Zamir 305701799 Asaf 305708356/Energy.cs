using System;

namespace Ex03.GarageLogic
{
    public abstract class Energy
    {
        private float m_MaxCapacity;
        private float m_CurrentCapacity;

        public float MaxCapacity
        {
            get { return m_MaxCapacity; }
            set { m_MaxCapacity = value; }
        }

        public float CurrentCapacity
        {
            get { return m_CurrentCapacity; }
            set
            {
                if (value>m_MaxCapacity)
                {
                    throw new ArgumentException("current energy must be less than maximum energy!",
                                                new ValueOutOfRangeException(0, m_MaxCapacity));
                }
                else
                {
                    m_CurrentCapacity = value;
                }
            }
        }
    }
}
