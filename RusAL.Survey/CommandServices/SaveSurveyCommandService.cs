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

            if (survey.FIO == null && survey.Experience == 0 && survey.Language == null && survey.Phone == null)
            {
                Console.WriteLine("Файл НЕ сохранён! Анкета пустая !");
            }
            else
            {
                _fileService.SaveSurveyFile(survey, out hasErrors);

                if (!hasErrors)
                {
                    Console.WriteLine("Файл успешно сохранён!");
                }
            }            

        }

    }
}
