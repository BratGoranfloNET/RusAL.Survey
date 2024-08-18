using RusAL.Survey.Models;

namespace RusAL.Survey.SurveyStrategy
{
    public class InputPhoneStrategy : IInputStrategy
    {
        public bool InputAlgorithmInterface(string strValue, SurveyItem survey)
        {              

            var inputError = false;

            survey.Phone = strValue;

            return inputError;

        }
    }
}
