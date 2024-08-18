using RusAL.Survey.Models;

namespace RusAL.Survey.SurveyStrategy
{
    public class InputDateStrategy : IInputStrategy
    {
        public bool InputAlgorithmInterface(string strValue, SurveyItem survey)
        {
            var inputError = false;

            try
            {                    
                var format = "dd.MM.yyyy";
                DateTime date = DateTime.ParseExact(strValue, format,
                System.Globalization.CultureInfo.InvariantCulture);
                survey.BirthDate = date;
                inputError = false;
                return inputError;
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка ввода Даты");
                inputError = true;
                return inputError;
            }
                        
        }        
    }
}
