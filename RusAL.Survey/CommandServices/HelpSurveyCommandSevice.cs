using RusAL.Survey.Commands.Abstract;
using RusAL.Survey.Models;

namespace RusAL.Survey.CommandServices
{
    /// <summary>
    /// Выйти из приложения
    /// </summary>
    public class HelpSurveyCommandSevice : ICommandService
    {

        public void Start(out bool hasErrors, SurveyItem survey, int startQuestion, string commandArg)
        {
            hasErrors = false;                      

        }

    }
}
