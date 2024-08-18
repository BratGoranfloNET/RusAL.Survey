using RusAL.Survey.Commands.Abstract;

namespace RusAL.Survey.CommandServices
{
    /// <summary>
    /// Выйти из приложения
    /// </summary>
    public class ExitSurveyCommandService : CommandService
    {
        public override void StartCommon(string commandArg)
        {                      
            Environment.Exit(0);
        }

    }
}
