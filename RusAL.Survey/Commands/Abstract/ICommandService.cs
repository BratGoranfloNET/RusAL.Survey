using RusAL.Survey.Models;

namespace RusAL.Survey.Commands.Abstract
{
    /// <summary>
    /// Интерфейс сервиса команды.
    /// </summary>    

    public interface ICommandService
    {
        /// <summary>
        /// Запуск команды.
        /// </summary>        
        void Start(SurveyItem survey, string commandArg, bool isSurvey );
    }

}
