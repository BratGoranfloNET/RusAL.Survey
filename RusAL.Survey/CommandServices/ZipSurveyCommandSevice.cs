using RusAL.Survey.Commands.Abstract;
using RusAL.Survey.Models;
using RusAL.Survey.Services.Abstract;

namespace RusAL.Survey.CommandServices
{
    /// <summary>
    /// Сохранит анкету в файл
    /// </summary>
    public class ZipSurveyCommandSevice : ICommandService
    {
        /// <summary>
        /// Работа с файлами
        /// </summary>
        private readonly IFileSurveyService _fileService;

        public ZipSurveyCommandSevice(IFileSurveyService fileService)
        {            
            _fileService = fileService;
        }

        public void Start(out bool hasErrors, SurveyItem survey, int startQuestion, string commandArg)
        {
            hasErrors = false;

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
