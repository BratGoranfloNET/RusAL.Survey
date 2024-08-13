using RusAL.Survey.Commands.Abstract;

namespace RusAL.Survey.Commands.Concrete
{
    /// <summary>
    /// Модель консольной команды.
    /// </summary>
    public class ConsoleCommand
    {
        /// <summary>
        /// Текст команды
        /// </summary>
        public string CommandText { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Сервис для выполнения
        /// </summary>
        public ICommandService Service { get; set; }


    }
}
