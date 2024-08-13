
using RusAL.Survey.Models;

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

        public static SurveyItem MapSurvey(SurveyItemDto dto)
        {
            var survey = new SurveyItem();
            survey.FIO = dto.FIO;
            var format = "dd.MM.yyyy";
            DateTime date = DateTime.ParseExact(dto.BirthDate, format,
            System.Globalization.CultureInfo.InvariantCulture);
            survey.BirthDate = date;
            survey.Language = dto.Language;
            int intValue;
            survey.Experience = int.TryParse(dto.Experience, out intValue) ? intValue : 0;
            survey.Phone = dto.Phone;

            return survey;
        }
    }
}
