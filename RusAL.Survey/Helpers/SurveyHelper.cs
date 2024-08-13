
namespace RusAL.Survey.Helpers
{
    public static class SurveyHelper
    {      
        // в случае нахождения внутренней  команды возвращаем номер вопроса
        public static int ChechInnerCommands(string command, int currQuestion)
        {
            var innerCommand1 = "-goto_question";
            var innerCommand2 = "-goto_prev_question";
            var innerCommand3 = "-restart_profile";            

            if (string.IsNullOrEmpty(command))
            {
                return -1;
            }

            if (command.Trim().Contains(innerCommand1))
            {
                var nextCommand = command.Replace(innerCommand1, "");
                return Convert.ToInt32(nextCommand.Trim()); 
            }

            if (command.Trim().Contains(innerCommand2))
            {                
                return currQuestion -= 1;
            }


            if (command.Trim().Contains(innerCommand3))
            {
                return 0;
            }

            return -1;
        }


        public static string[] GetQustions()
        {
            var qustions = new string[]
            {
                "Введите ФИО",
                "Введите Дату рождения (ДД.ММ.ГГГГ)",
                "Любимый язык программирования (только указанные варианты: PHP, JavaScript, C, C++, Java, C#, Python, Ruby)",
                "Введите опыт программирования на указанном языке (Полных лет)",
                "Введите Мобильный телефон",
            };

            return qustions;

        }

        public static string GetYearsString(int years)
        {
            var y = ((years / 10 == 1) || (years - 1) % 10 > 3) ? "лет" : ((years % 10 == 1) ? "год" : "года");

            return y;
        }
    }
}
