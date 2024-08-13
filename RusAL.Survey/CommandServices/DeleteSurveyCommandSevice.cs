using RusAL.Survey.Commands.Abstract;
using RusAL.Survey.Models;
using RusAL.Survey.Services.Abstract;

namespace RusAL.Survey.CommandServices
{
    /// <summary>
    /// Удалим файл
    /// </summary>
    public class DeleteSurveyCommandSevice : ICommandService
    {        /// <summary>
             /// Работа с файлами
             /// </summary>
        private readonly IFileSurveyService _fileService;

        public DeleteSurveyCommandSevice(IFileSurveyService fileService)
        {
            _fileService = fileService;
        }

        public void Start(out bool hasErrors, SurveyItem survey, int startQuestion, string commandArg)
        {
            hasErrors = false;
            _fileService.DeleteSurveyByFileName(commandArg.Trim(), out hasErrors);
            if (!hasErrors)
            {
                Console.WriteLine("Файл удалён!");
            }

        }
    }
}
