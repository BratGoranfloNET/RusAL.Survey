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
            var strValue = string.Empty;
            var exitResult = false;
            while (true)
            {
                Console.WriteLine(question);
                Console.ForegroundColor = ConsoleColor.Yellow;

                strValue = Console.ReadLine();
                checkInnerCommand = SurveyHelper.CheckInnerCommands(strValue, i, survey);

                if (checkInnerCommand >= 0)
                {
                    survey.NextQuestion = checkInnerCommand;
                    exitResult = true;
                    break;                   
                }
                else 
                {
                    var isError = strategy.InputAlgorithmInterface(strValue, survey);
                    if (isError)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        continue;
                    }
                    else
                    {
                        exitResult = false;
                        break;
                    }
                                       
                }                
            }

            return exitResult;

        }
    }
}
