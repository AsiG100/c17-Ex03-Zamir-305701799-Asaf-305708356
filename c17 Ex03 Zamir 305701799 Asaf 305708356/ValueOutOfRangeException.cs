using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c17_Ex03_Zamir_305701799_Asaf_305708356
{
    class ValueOutOfRangeException : Exception
    {
        float m_MaxValue;
        float m_MinValue;

        public ValueOutOfRangeException(string i_Messege, float i_Max, float i_Min)
                                         :base(i_Messege)
        {
            this.m_MaxValue = i_Max;
            this.m_MinValue = i_Min;
        }
    }
}
