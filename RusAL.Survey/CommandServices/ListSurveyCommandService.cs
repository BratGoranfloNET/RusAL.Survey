using RusAL.Survey.Commands.Abstract;
using RusAL.Survey.Services.Abstract;

namespace RusAL.Survey.CommandServices
{
    /// <summary>
    /// Получить список всех анкет
    /// </summary>
    public class ListSurveyCommandService : CommandService
    {   
        /// <summary>
        /// Работа с файлами
        /// </summary>
        private readonly IFileSurveyService _fileService;

        public ListSurveyCommandService(IFileSurveyService fileService)
        {
            _fileService = fileService;
        }

        public override void StartCommon(string commandArg)
        {
            var hasErrors = false;

            var files = _fileService.GetFileList();

            Console.WriteLine("Список файлов всех анкет:");
            
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }

        }
    }
}
