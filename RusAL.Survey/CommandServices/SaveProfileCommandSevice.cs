using Q101.ConsoleHelper.Abstract;
using RusAL.Survey.Commands.Abstract;
using RusAL.Survey.Models;
using RusAL.Survey.Services.Abstract;

namespace RusAL.Survey.CommandServices
{
    /// <summary>
    /// Сохранит анкету в файл
    /// </summary>
    public class SaveProfileCommandSevice : ICommandService
    {
        /// <summary>
        /// Работа с консолью.
        /// </summary>
        private readonly IQ101ConsoleHelper _consoleHelper;

        /// <summary>
        /// Работа с файлами
        /// </summary>
        private readonly IFileSurveyService _fileService;

        public SaveProfileCommandSevice(IQ101ConsoleHelper consoleHelper, IFileSurveyService fileService)
        {
            _consoleHelper = consoleHelper;
            _fileService = fileService;
        }

        public void Start(out bool hasErrors, SurveyItem survey, int startQuestion)
        {
             hasErrors = false;
            _fileService.WriteSurvayFile(survey);            
        }

    }
}
