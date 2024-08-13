using RusAL.Survey.Models;

namespace RusAL.Survey.Commands.Abstract
{
    /// <summary>
    /// Обработчик консольных команд.
    /// </summary>
    public interface IConsoleCommandHandler
    {
        /// <summary>
        /// Запуск обработки команд.
        /// </summary>
        /// <param name="hasErrors">Наличие некритичных ошибок при выполнении команд.</param>
        void Run(out bool hasErrors, out bool isExit, SurveyItem survey);
    }
}
