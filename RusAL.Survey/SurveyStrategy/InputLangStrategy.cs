using RusAL.Survey.Helpers;
using RusAL.Survey.Models;

namespace RusAL.Survey.SurveyStrategy
{
    public class InputLangStrategy : IInputStrategy
    {
        public  bool InputAlgorithmInterface(int i, string question, SurveyItem survey)
        {
            int checkInnerCommand = 0;
            bool exitFlag = false;

            while (true)
            {
                
                var lang = new string[] { "PHP", "JavaScript", "C", "C++", "Java", "C#", "Python", "Ruby" };
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(question);
                var strValue = Console.ReadLine();
                checkInnerCommand = SurveyHelper.CheckInnerCommands(strValue, i, survey);
                if (checkInnerCommand >= 0)
                {
                    survey.NextQuestion = checkInnerCommand;
                    exitFlag = true;
                    break;
                }
                if (lang.Contains(strValue.Trim()))
                {
                    survey.Language = strValue;
                    break;
                }
                else 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка ввода языка программирования");
                }
                
            }

            return exitFlag;
        }
    }
}
