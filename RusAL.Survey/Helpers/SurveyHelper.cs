﻿using RusAL.Survey.Models;

namespace RusAL.Survey.Helpers
{
    public static class SurveyHelper
    {      
        // в случае нахождения внутренней  команды возвращаем номер вопроса
        public static int CheckInnerCommands(string command, int currQuestion, SurveyItem survey)
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
                try
                {
                    var args = command.Split(' ');
                    if (args.Length == 1)
                    {
                        return -1;
                    }
                    else if(args.Length == 2)
                    {
                        survey.InnerCommand = true;
                        var nextCommandStr = args[1];
                        var nextCommand = Convert.ToInt32(nextCommandStr.Trim());
                        return nextCommand -1;
                    }

                }
                catch 
                {
                    return -1;
                }
            }

            if (command.Trim().Contains(innerCommand2))
            {
                survey.InnerCommand = true;
                return currQuestion -= 1;
            }

            if (command.Trim().Contains(innerCommand3))
            {
                survey.FIO = string.Empty;
                survey.BirthDate = DateTime.MinValue;
                survey.Language = string.Empty;
                survey.Experience = 0;
                survey.Phone = string.Empty;
                survey.InnerCommand = true;
                survey.NextQuestion = 0;
                return 0;
            }

            return -1;
        }


        public static string[] GetQustions()
        {
            var questions = new string[]
            {
                "Введите ФИО >",
                "Введите Дату рождения (ДД.ММ.ГГГГ) >",
                "Любимый язык программирования (только указанные варианты: PHP, JavaScript, C, C++, Java, C#, Python, Ruby) >",
                "Введите опыт программирования на указанном языке (Полных лет) >",
                "Введите Мобильный телефон >",
            };

            return questions;

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
