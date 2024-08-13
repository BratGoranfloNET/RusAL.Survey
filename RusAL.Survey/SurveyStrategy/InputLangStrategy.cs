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
                try
                {
                    var lang = new string[] { "PHP", "JavaScript", "C", "C++", "Java", "C#", "Python", "Ruby" };
                    Console.WriteLine(question);
                    var langString = Console.ReadLine();
                    if (lang.Contains(langString.Trim()))
                    {
                        survey.Language = langString;
                        break;
                    }
                    checkInnerCommand = SurveyHelper.ChechInnerCommands(langString, i);
                    if (checkInnerCommand >= 0)
                    {
                        survey.NextQuestion = checkInnerCommand;
                        exitFlag = true;
                        break;
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка ввода языка программирования");
                }
            }

            return exitFlag;
        }
    }
}
