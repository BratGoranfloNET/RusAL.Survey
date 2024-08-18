using RusAL.Survey.Models;

namespace RusAL.Survey.SurveyStrategy
{
    public class InputExpStrategy : IInputStrategy
    {
        public void InputAlgorithmInterface(string strValue, SurveyItem survey)
        {            
            while (true)
            {
                try
                {                   
                    survey.Experience = Convert.ToInt32(strValue);
                    break;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка ввода опыта");
                }
            }
        }
    }
}
