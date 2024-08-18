using RusAL.Survey.Commands.Abstract;
using RusAL.Survey.Services.Abstract;

namespace RusAL.Survey.CommandServices
{
    /// <summary>
    /// Получить список  анкет сохраненных сегодня
    /// </summary>
    public class ListToDaySurveyCommandService : CommandService
    {   
        /// <summary>
        /// Работа с файлами
        /// </summary>
        private readonly IFileSurveyService _fileService;

        public ListToDaySurveyCommandService(IFileSurveyService fileService)
        {
            _fileService = fileService;
        }

        public override void StartCommon(string commandArg)
        {
            var files = _fileService.GetFileListToday();

            Console.WriteLine("Список файлов анкет сохраненных сегодня:");
            
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
        }
    }
}
