using System;

namespace Ex03.GarageLogic
{
    public class Questioning
    {
        private Type m_AnswerType;

        public Questioning(string i_Question, Type i_AnswerType)
        {
            Question = i_Question;
            m_AnswerType = i_AnswerType;
        }

        public string Question { get; set; }

        public string Answer { get; set; }

        public Type AnswerType
        {
            get { return m_AnswerType; }
        }

        public override string ToString()
        {
            return Question;
        }

        public bool ValidateAnswer()
        {
            bool validator;

            try
            {
                var dummy = Convert.ChangeType(Answer, m_AnswerType);
                validator = true;
            }
            catch (ArgumentNullException)
            {
                validator = false;
            }
            catch (InvalidCastException)
            {
                validator = false;
            }
            catch (FormatException)
            {
                validator = false;
            }
            catch (OverflowException)
            {
                validator = false;
            }

            return validator;
        }
    }
}
