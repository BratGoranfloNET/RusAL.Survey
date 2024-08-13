using RusAL.Survey.Helpers;
using RusAL.Survey.Models;

namespace RusAL.Survey.SurveyStrategy
{
    public class InputExpStrategy : IInputStrategy
    {
        public  bool InputAlgorithmInterface(int i, string question, SurveyItem survey)
        {
            int checkInnerCommand = 0;
            bool exitFlag = false;

            Console.WriteLine(question);
            var experience = Console.ReadLine();
            checkInnerCommand = SurveyHelper.ChechInnerCommands(experience, i);
            if (checkInnerCommand >= 0)
            {
                survey.NextQuestion = checkInnerCommand;
                exitFlag = true;
            }
            survey.Experience = Convert.ToInt32(experience);
            return exitFlag;
        }
    }
}
