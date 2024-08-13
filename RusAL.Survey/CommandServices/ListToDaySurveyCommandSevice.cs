using RusAL.Survey.Commands.Abstract;
using RusAL.Survey.Models;
using RusAL.Survey.Services.Abstract;

namespace RusAL.Survey.CommandServices
{
    /// <summary>
    /// Получить список  анкет сохраненных сегодня
    /// </summary>
    public class ListToDaySurveyCommandSevice : ICommandService
    {   
        /// <summary>
        /// Работа с файлами
        /// </summary>
        private readonly IFileSurveyService _fileService;

        public ListToDaySurveyCommandSevice(IFileSurveyService fileService)
        {
            _fileService = fileService;
        }

        public void Start(out bool hasErrors, SurveyItem survey, int startQuestion, string commandArg)
        {
            hasErrors = false;

            var files = _fileService.GetFileListToday();

            Console.WriteLine("Список файлов анкет сохраненных сегодня:");
            
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }

        }
    }
}
