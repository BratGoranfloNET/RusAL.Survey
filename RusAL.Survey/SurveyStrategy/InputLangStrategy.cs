using RusAL.Survey.Models;

namespace RusAL.Survey.SurveyStrategy
{
    public class InputLangStrategy : IInputStrategy
    {
        public  void InputAlgorithmInterface(string strValue, SurveyItem survey)
        {          
            while (true)
            {                
                var lang = new string[] { "PHP", "JavaScript", "C", "C++", "Java", "C#", "Python", "Ruby" };
                                
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
        }
    }
}
