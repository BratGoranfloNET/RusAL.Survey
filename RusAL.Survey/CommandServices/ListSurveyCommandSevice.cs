using RusAL.Survey.Commands.Abstract;
using RusAL.Survey.Models;
using RusAL.Survey.Services.Abstract;

namespace RusAL.Survey.CommandServices
{
    /// <summary>
    /// Получить список всех анкет
    /// </summary>
    public class ListSurveyCommandSevice : ICommandService
    {   
        /// <summary>
        /// Работа с файлами
        /// </summary>
        private readonly IFileSurveyService _fileService;

        public ListSurveyCommandSevice(IFileSurveyService fileService)
        {
            _fileService = fileService;
        }

        public void Start(out bool hasErrors, SurveyItem survey, int startQuestion, string commandArg)
        {
            hasErrors = false;

            var files = _fileService.GetFileList();

            Console.WriteLine("Список файлов всех анкет:");
            
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }

        }
    }
}
