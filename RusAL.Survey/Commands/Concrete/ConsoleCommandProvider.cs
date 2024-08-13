using RusAL.Survey.Commands.Abstract;
using RusAL.Survey.CommandServices;

namespace RusAL.Survey.Commands.Concrete
{
    /// <summary>
    /// Провайдер консольных команд.
    /// </summary>
    public class ConsoleCommandProvider : IConsoleCommandProvider
    {
        /// <inheritdoc />
        public IList<ConsoleCommand> Commands { get; }

        public ConsoleCommandProvider(
                    NewProfileCommandSevice newProfile, 
                    SaveProfileCommandSevice saveProfile,
                    StatisticsCommandSevice statistics
                    )
        {
            Commands = new List<ConsoleCommand>(13)
            {
                Create("-new_profile", "Заполнение анкеты", newProfile),
                Create("-save", "Сохранение анкеты", saveProfile),
                Create("-statistics", "Статистика заполненных анкет", statistics)
            };

        }

        /// <summary>
        /// Создать команду.
        /// </summary>
        /// <param name="commandText">Текст команды.</param>
        /// <param name="title">Название.</param>
        /// <param name="service">Сервис команды.</param>
        private ConsoleCommand Create(string commandText, string title, ICommandService service)
        {
            var command = new ConsoleCommand
            {
                CommandText = commandText,
                Title = title,
                Service = service
            };

            return command;
        }

    }
}
