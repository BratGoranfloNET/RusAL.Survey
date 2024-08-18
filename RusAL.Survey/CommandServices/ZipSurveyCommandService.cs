using RusAL.Survey.Commands.Abstract;
using RusAL.Survey.Services.Abstract;

namespace RusAL.Survey.CommandServices
{
    /// <summary>
    /// Сохранит анкету в zip файл
    /// </summary>
    public class ZipSurveyCommandService : CommandService
    {
        /// <summary>
        /// Работа с файлами
        /// </summary>
        private readonly IFileSurveyService _fileService;

        public ZipSurveyCommandService(IFileSurveyService fileService)
        {            
            _fileService = fileService;
        }

        public override void StartCommon(string commandArg)
        {
            var hasErrors = false;

            var argArr = commandArg.Split(" ");
            var arg1 = argArr[0];
            var arg2 = argArr[1];

            _fileService.ZipSurvey(arg1, arg2, out hasErrors);

            if(!hasErrors)
            {
                Console.WriteLine("Файл заархивирован!");
            }

        }

    }
}
