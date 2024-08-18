using RusAL.Survey.Commands.Abstract;
using RusAL.Survey.Models;
using RusAL.Survey.Services.Abstract;

namespace RusAL.Survey.CommandServices
{
    /// <summary>
    /// Сохранит анкету в файл
    /// </summary>
    public class SaveSurveyCommandService : CommandService
    {
        /// <summary>
        /// Работа с файлами
        /// </summary>
        private readonly IFileSurveyService _fileService;

        public SaveSurveyCommandService(IFileSurveyService fileService)
        {           
            _fileService = fileService;
        }

        public override void StartSurvey(SurveyItem survey, string commandArg)
        {
             var hasErrors = false;
            _fileService.SaveSurvayFile(survey, out hasErrors);

            if (!hasErrors)
            {
                Console.WriteLine("Файл успешно сохранён!");
            }
        }

    }
}
