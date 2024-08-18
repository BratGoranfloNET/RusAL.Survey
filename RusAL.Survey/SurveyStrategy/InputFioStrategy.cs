using RusAL.Survey.Models;

namespace RusAL.Survey.SurveyStrategy
{
    public class InputFioStrategy : IInputStrategy
    {
        public  void InputAlgorithmInterface(string strValue, SurveyItem survey)
        {                           
            survey.FIO = strValue;            
        }
    }
}
