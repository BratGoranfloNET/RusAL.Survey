﻿using RusAL.Survey.Commands.Abstract;
using RusAL.Survey.Helpers;
using RusAL.Survey.Models;
using RusAL.Survey.Services.Abstract;

namespace RusAL.Survey.CommandServices
{
    /// <summary>
    /// Статистика по анкетам
    /// </summary>
    public class StatisticsCommandService : CommandService
    {        
        /// <summary>
        /// Работа с файлами
        /// </summary>
        private readonly IFileSurveyService _fileService;

        public StatisticsCommandService(IFileSurveyService fileService)
        {            
            _fileService = fileService;
        }

        public override void StartCommon(string commandArg)
        {
            var dtoList =  _fileService.GetSurveys();

            var surList = new List<SurveyItem>();
            DateTime now = DateTime.Today;
            var ageSum = 0;
            //Замаппим dto
            foreach (var dto in dtoList)
            {
                var sur = SurveyHelper.MapSurvey(dto);
                surList.Add(sur);

                int age = now.Year - sur.BirthDate.Year;
                if (sur.BirthDate > now.AddYears(-age)) age--;

                ageSum = ageSum + age;
            }

            var lang = surList.Select(x => x.Language)
                .GroupBy(g => g)
                .OrderByDescending(o => o.Count())
                .FirstOrDefault()?.Key;

            var maxExpYears = surList.Select(x => x.Experience).ToArray().Max();
            string yearsString = SurveyHelper.GetYearsString(maxExpYears);
            var fio = surList.Where(x => x.Experience == maxExpYears).FirstOrDefault()?.FIO;

            Console.WriteLine("Статистика");
            Console.WriteLine($"1. Средний возраст всех опрошенных: {ageSum/surList.Count}");
            Console.WriteLine($"2. Самый популярный язык программирования: {lang}");
            Console.WriteLine($"3. Самый опытный программист: {maxExpYears} {yearsString} у {fio}");

        }
    }
}
