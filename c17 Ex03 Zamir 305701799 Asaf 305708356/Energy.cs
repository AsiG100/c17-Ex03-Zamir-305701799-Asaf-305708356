using System;

namespace Ex03.GarageLogic
{
    public abstract class Energy
    {
        private float m_CurrentCapacity;

        public float MaxCapacity { get; set; }

        public float CurrentCapacity
        {
            get { return m_CurrentCapacity; }
            set
            {
                if (value>MaxCapacity)
                {
                    throw new ArgumentException("current engine energy must be less than maximum energy!",
                                                new ValueOutOfRangeException(0, MaxCapacity));
                }

                m_CurrentCapacity = value;              
            }
        }

    }
}
