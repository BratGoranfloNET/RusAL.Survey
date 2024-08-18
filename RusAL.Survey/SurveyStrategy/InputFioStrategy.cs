using RusAL.Survey.Models;

namespace RusAL.Survey.SurveyStrategy
{
    public class InputFioStrategy : IInputStrategy
    {
        public bool InputAlgorithmInterface(string strValue, SurveyItem survey)
        {
            var inputError = false;

            if(!string.IsNullOrWhiteSpace(strValue))
            {
                survey.FIO = strValue;
                inputError = false;
                return inputError;

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка ввода ФИО");
                inputError = true;
                return inputError;
            }

        }
    }
}
