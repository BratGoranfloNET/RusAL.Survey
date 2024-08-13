using RusAL.Survey.Commands.Concrete;

namespace RusAL.Survey.Commands.Abstract
{
    /// <summary>
    /// Провайдер консольных команд.
    /// </summary>
    public interface IConsoleCommandProvider
    {
        /// <summary>
        /// Список команд консоли.
        /// </summary>
        IList<ConsoleCommand> Commands { get; }

    }
}
