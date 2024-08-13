using RusAL.Survey.Helpers;
using RusAL.Survey.Models;

namespace RusAL.Survey.SurveyStrategy
{
    public class InputFioStrategy : IInputStrategy
    {
        public  bool InputAlgorithmInterface(int i, string question, SurveyItem survey)
        {
            int checkInnerCommand = 0;
            bool exitFlag = false;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(question);
            var strValue = Console.ReadLine();
            checkInnerCommand = SurveyHelper.CheckInnerCommands(strValue, i, survey);
            if (checkInnerCommand >= 0)
            {
                survey.NextQuestion = checkInnerCommand;
                exitFlag = true;
            }
            survey.FIO = strValue;
            return exitFlag;
        }
    }
}
