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
                    NewSurveyCommandSevice newSurvey,
                    SaveSurveyCommandSevice saveSurvey,
                    StatisticsCommandSevice statistics,
                    FindSurveyCommandSevice findSurvey,
                    DeleteSurveyCommandSevice deleteSurvey
                    )
        {
            Commands = new List<ConsoleCommand>(15)
            {
                Create("-new_profile", "Заполнение анкеты", newSurvey),
                Create("-save", "Сохранение анкеты", saveSurvey),
                Create("-statistics", "Статистика заполненных анкет", statistics),               
                Create("-find", "Найти анкету и показать данные анкеты", findSurvey),
                Create("-delete", "Удалить указанную анкету", deleteSurvey)
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
