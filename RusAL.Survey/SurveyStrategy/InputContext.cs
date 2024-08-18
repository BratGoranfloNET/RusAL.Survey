using RusAL.Survey.Helpers;
using RusAL.Survey.Models;

namespace RusAL.Survey.SurveyStrategy
{
    public class InputContext
    {
        IInputStrategy strategy;

        public InputContext(IInputStrategy strategy)
        {
            this.strategy = strategy;
        }

        public bool Input(int i, string question, SurveyItem survey)
        {
            int checkInnerCommand = 0;

            Console.WriteLine(question);
            Console.ForegroundColor = ConsoleColor.Yellow;
            
            var strValue = Console.ReadLine();
            checkInnerCommand = SurveyHelper.CheckInnerCommands(strValue, i, survey);
            
            if (checkInnerCommand >= 0)
            {
                survey.NextQuestion = checkInnerCommand;
                return true;                
            }

            strategy.InputAlgorithmInterface(strValue, survey);

            return false;
        }
    }
}
