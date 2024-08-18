using RusAL.Survey.Models;

namespace RusAL.Survey.SurveyStrategy
{
    public class InputFioStrategy : IInputStrategy
    {
        public bool InputAlgorithmInterface(string strValue, SurveyItem survey)
        {
            var inputError = false;

            survey.FIO = strValue;
                        
            return inputError;
        }
    }
}
