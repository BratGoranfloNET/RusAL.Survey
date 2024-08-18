using RusAL.Survey.Models;

namespace RusAL.Survey.SurveyStrategy
{
    public class InputLangStrategy : IInputStrategy
    {
        public bool InputAlgorithmInterface(string strValue, SurveyItem survey)
        {
                var inputError = false;
            
                var lang = new string[] { "PHP", "JavaScript", "C", "C++", "Java", "C#", "Python", "Ruby" };
                                
                if (lang.Contains(strValue.Trim()))
                {
                    survey.Language = strValue;
                    inputError = false;
                    return inputError;
                }
                else 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка ввода языка программирования");
                    inputError = true;
                    return inputError;
                }
                
            }
        }
    
}
