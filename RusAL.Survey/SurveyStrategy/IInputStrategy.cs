using RusAL.Survey.Models;

namespace RusAL.Survey.SurveyStrategy
{
    public interface IInputStrategy
    {
        public  bool InputAlgorithmInterface(string strValue, SurveyItem survey);        
    }
}
