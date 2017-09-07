using System;

namespace Ex03.GarageLogic
{
    public class Questioning
    {
        private string m_Question;
        private string m_Answer;
        private Type m_AnswerType;

        public Questioning(string i_Question, Type i_AnswerType)
        {
            m_Question = i_Question;
            m_AnswerType = i_AnswerType;
        }

        public string Question
        {
            get { return m_Question; }
            set { m_Question = value; }
        }

        public string Answer
        {
            get { return m_Answer; }
            set { m_Answer = value; }
        }

        public Type AnswerType
        {
            get { return m_AnswerType; }
        }

        public override string ToString()
        {
            return m_Question;
        }

        public bool ValidateAnswer()
        {
            bool validator;

            try
            {
                var dummy = Convert.ChangeType(m_Answer, m_AnswerType);
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
