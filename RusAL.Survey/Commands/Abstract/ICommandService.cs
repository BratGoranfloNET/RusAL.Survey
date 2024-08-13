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
        /// <param name="hasErrors">Наличие некритичных ошибок при выполнении.</param>
        void Start(out bool hasErrors, SurveyItem survey, int startQuestion = 0);
    }
}
