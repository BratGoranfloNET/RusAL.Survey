using RusAL.Survey.Commands.Abstract;
using RusAL.Survey.Models;
using RusAL.Survey.Services.Abstract;

namespace RusAL.Survey.CommandServices
{
    /// <summary>
    /// Выйти из приложения
    /// </summary>
    public class ExitSurveyCommandSevice : ICommandService
    {

        public void Start(out bool hasErrors, SurveyItem survey, int startQuestion, string commandArg)
        {
            hasErrors = false;
           
            Environment.Exit(0);

        }

    }
}
