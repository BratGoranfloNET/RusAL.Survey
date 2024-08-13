using RusAL.Survey.Helpers;
using RusAL.Survey.Models;

namespace RusAL.Survey.SurveyStrategy
{
    public class InputPhoneStrategy : IInputStrategy
    {
        public  bool InputAlgorithmInterface(int i, string question, SurveyItem survey)
        {
            int checkInnerCommand = 0;
            bool exitFlag = false;

            Console.WriteLine(question);
            var phone = Console.ReadLine();
            checkInnerCommand = SurveyHelper.ChechInnerCommands(phone, i);
            if (checkInnerCommand >= 0)
            {
                survey.NextQuestion = checkInnerCommand;
                exitFlag = true;
            }
            survey.Phone = phone;
            return exitFlag;
        }
    }
}
