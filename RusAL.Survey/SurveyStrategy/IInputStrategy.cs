using RusAL.Survey.Models;

namespace RusAL.Survey.SurveyStrategy
{
    public interface IInputStrategy
    {
        public  bool InputAlgorithmInterface(int i, string question, SurveyItem survey);
        
    }
}
