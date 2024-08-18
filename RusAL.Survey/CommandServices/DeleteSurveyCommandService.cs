using RusAL.Survey.Commands.Abstract;
using RusAL.Survey.Services.Abstract;

namespace RusAL.Survey.CommandServices
{
    /// <summary>
    /// Удалим файл
    /// </summary>
    public class DeleteSurveyCommandService : CommandService
    {  
        /// <summary>
        /// Работа с файлами
        /// </summary>
        private readonly IFileSurveyService _fileService;

        public DeleteSurveyCommandService(IFileSurveyService fileService)
        {
            _fileService = fileService;
        }

        public override void StartCommon(string commandArg)
        {
            var hasErrors = false;

            _fileService.DeleteSurveyByFileName(commandArg.Trim(), out hasErrors);

            if (!hasErrors)
            {
                Console.WriteLine("Файл удалён!");
            }
        }
    }
}
