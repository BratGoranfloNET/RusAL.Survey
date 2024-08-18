using RusAL.Survey.Models;

namespace RusAL.Survey.Commands.Abstract
{
    public class CommandService : ICommandService
    {
        public void Start(bool isSurvey, SurveyItem survey, string commandArg)
        {
            if (isSurvey) StartSurvey(survey, commandArg);
            else StartCommon( commandArg);
        }        

        public virtual void StartSurvey(SurveyItem survey,  string commandArg) {}

        public virtual void StartCommon(string commandArg) { }
        
    }
}
