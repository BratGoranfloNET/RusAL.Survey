using RusAL.Survey.Commands.Abstract;
using RusAL.Survey.Models;
using RusAL.Survey.Services.Abstract;

namespace RusAL.Survey.CommandServices
{
    /// <summary>
    /// Сохранит анкету в файл
    /// </summary>
    public class SaveSurveyCommandSevice : ICommandService
    {
        /// <summary>
        /// Работа с файлами
        /// </summary>
        private readonly IFileSurveyService _fileService;

        public SaveSurveyCommandSevice(IFileSurveyService fileService)
        {           
            _fileService = fileService;
        }

        public void Start(out bool hasErrors, SurveyItem survey, int startQuestion, string commandArg)
        {
             hasErrors = false;
            _fileService.SaveSurvayFile(survey, out hasErrors);

            if (!hasErrors)
            {
                Console.WriteLine("Файл успешно сохранён!");
            }
        }

    }
}
