using Q101.ConsoleHelper.Abstract;
using RusAL.Survey.Commands.Abstract;
using RusAL.Survey.Models;
using RusAL.Survey.Services.Abstract;

namespace RusAL.Survey.CommandServices
{
    /// <summary>
    /// Статистика
    /// </summary>
    public class StatisticsCommandSevice : ICommandService
    {
        /// <summary>
        /// Работа с консолью.
        /// </summary>
        private readonly IQ101ConsoleHelper _consoleHelper;

        /// <summary>
        /// Работа с файлами
        /// </summary>
        private readonly IFileSurveyService _fileService;

        public StatisticsCommandSevice(IQ101ConsoleHelper consoleHelper, IFileSurveyService fileService)
        {
            _consoleHelper = consoleHelper;
            _fileService = fileService;
        }

        public void Start(out bool hasErrors, SurveyItem survey, int startQuestion)
        {
             hasErrors = false;

            var dtoList =  _fileService.GetSurveys();

            var surList = new List<SurveyItem>();
            DateTime now = DateTime.Today;
            var ageSum = 0;
            //замаппим dto
            foreach (var dto in dtoList)
            {
                var sur = new SurveyItem();

                sur.FIO = dto.FIO;
                var format = "dd.MM.yyyy";
                DateTime date = DateTime.ParseExact(dto.BirthDate, format,
                System.Globalization.CultureInfo.InvariantCulture);
                sur.BirthDate = date;
                sur.Language = dto.Language;
                int intValue;              
                sur.Experience = int.TryParse(dto.Experience, out intValue) ? intValue : 0;
                sur.Phone = dto.Phone;
                surList.Add(sur);

                int age = now.Year - sur.BirthDate.Year;
                if (sur.BirthDate > now.AddYears(-age)) age--;

                ageSum = ageSum + age;
            }

            var lang = surList.Select(x => x.Language)
                .GroupBy(g => g)
                .OrderByDescending(o => o.Count())
                .FirstOrDefault()?.Key;

            var maxExp = surList.Select(x => x.Experience).ToArray().Max();
            var fio = surList.Where(x => x.Experience == maxExp).FirstOrDefault()?.FIO;

            Console.WriteLine("Статистика");
            Console.WriteLine($"Средний возраст:{ageSum/surList.Count}");
            Console.WriteLine($"Самый популярный язык:{lang}");
            Console.WriteLine($"Макисмальный опыт:{maxExp} у {fio}");
        }

    }
}
