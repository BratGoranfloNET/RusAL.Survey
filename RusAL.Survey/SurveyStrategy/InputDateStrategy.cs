using RusAL.Survey.Helpers;
using RusAL.Survey.Models;

namespace RusAL.Survey.SurveyStrategy
{
    public class InputDateStrategy : IInputStrategy
    {
        public bool InputAlgorithmInterface(int i, string question, SurveyItem survey)
        {
            int checkInnerCommand = 0;
            bool exitFlag = false;

            while (true)
            {
                try
                {
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
                    var format = "dd.MM.yyyy";
                    DateTime date = DateTime.ParseExact(strValue, format,
                    System.Globalization.CultureInfo.InvariantCulture);
                    survey.BirthDate = date;
                    break;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка ввода Даты");
                }
            }

            return exitFlag;

        }
        
    }
}
