using RusAL.Survey.Models;

namespace RusAL.Survey.SurveyStrategy
{
    public class InputPhoneStrategy : IInputStrategy
    {
        public  void InputAlgorithmInterface(string strValue, SurveyItem survey)
        {               
            survey.Phone = strValue;           
        }
    }
}
