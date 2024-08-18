using RusAL.Survey.Commands.Abstract;
using RusAL.Survey.Services.Abstract;

namespace RusAL.Survey.CommandServices
{
    /// <summary>
    /// Найти анкету и вывести 
    /// </summary>
    public class FindSurveyCommandService : CommandService
    {
        /// <summary>
        /// Работа с файлами
        /// </summary>
        private readonly IFileSurveyService _fileService;

        public FindSurveyCommandService(IFileSurveyService fileService)
        {            
            _fileService = fileService;
        }

        public override void StartCommon(string commandArg)
        {           
            var dto = _fileService.GetSurveyByFileName(commandArg.Trim());

            Console.WriteLine($"1. ФИО: {dto.FIO}");
            Console.WriteLine($"2. Дата рождения: {dto.BirthDate}");
            Console.WriteLine($"3. Любимый язык программирования: {dto.Language}");
            Console.WriteLine($"4. Опыт программирования на указанном языке: {dto.Experience}");
            Console.WriteLine($"5. Мобильный телефон:{dto.Phone}");
            Console.WriteLine($"Анкета заполнена: {dto.Created}");

        }
    }
}
