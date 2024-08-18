using RusAL.Survey.Models;

namespace RusAL.Survey.Commands.Abstract
{
    public class CommandService : ICommandService
    {
        public void Start( SurveyItem survey, string commandArg, bool isSurvey)
        {
            if (isSurvey)
            {
                StartSurvey(survey, commandArg);
            }
            else 
            {
                StartCommon(commandArg);
            }
           
        }        

        public virtual void StartSurvey(SurveyItem survey,  string commandArg) {}

        public virtual void StartCommon(string commandArg) { }
        
    }
}
