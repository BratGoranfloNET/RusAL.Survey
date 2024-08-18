using RusAL.Survey.Models;

namespace RusAL.Survey.SurveyStrategy
{
    public class InputDateStrategy : IInputStrategy
    {
        public void InputAlgorithmInterface(string strValue, SurveyItem survey)
        {         
            while (true)
            {
                try
                {                    
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
            
        }        
    }
}
