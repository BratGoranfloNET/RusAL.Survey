using RusAL.Survey.Models;

namespace RusAL.Survey.SurveyStrategy
{
    public class InputExpStrategy : IInputStrategy
    {
        public bool InputAlgorithmInterface(string strValue, SurveyItem survey)
        {
            var inputError = false;

            try
            {
                survey.Experience = Convert.ToInt32(strValue);
                inputError = false;
                return inputError;
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка ввода опыта");
                inputError = true;
                return inputError;
            }

        }
    }
}
