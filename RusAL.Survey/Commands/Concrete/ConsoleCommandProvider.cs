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
                    DeleteSurveyCommandSevice deleteSurvey,
                    ListSurveyCommandSevice listSurvey,
                    ListToDaySurveyCommandSevice listTodaySurvey,
                    ZipSurveyCommandSevice zipSurvey,
                    ExitSurveyCommandSevice exit,
                    HelpSurveyCommandSevice help
                    )
        {
            Commands = new List<ConsoleCommand>(15)
            {
                Create("-new_profile", "Заполнение анкеты", newSurvey, false),
                Create("-save", "Сохранение анкеты", saveSurvey, false),
                Create("-statistics", "Статистика заполненных анкет", statistics, false),
                Create("-goto_question", "Вернуться к указанному вопросу", null, true),
                Create("-goto_prev_question", "Вернуться к предыдущему вопросу", null, true),
                Create("-restart_profile", "Заполнить анкету заново", null, true),
                Create("-find", "Найти анкету и показать данные анкеты", findSurvey, false),
                Create("-delete", "Удалить указанную анкету", deleteSurvey, false),
                Create("-list", "Показать список названий файлов всех сохранённых анкет", listSurvey, false),
                Create("-list_today", "Показать список названий файлов сохранённых анкет сегодня", listTodaySurvey, false),
                Create("-zip", "Запаковать указанную анкету", zipSurvey, false),
                Create("-exit", "Выйти из приложения", exit, false),
                Create("-help", "Показать список доступных команд", help, false)

            };

        }

        /// <summary>
        /// Создать команду.
        /// </summary>
        /// <param name="commandText">Текст команды.</param>
        /// <param name="title">Название.</param>
        /// <param name="service">Сервис команды.</param>
        private ConsoleCommand Create(string commandText, string title, ICommandService service, bool inner)
        {
            var command = new ConsoleCommand
            {
                CommandText = commandText,
                Title = title,
                Service = service, 
                IsInnerCommand = inner
            };

            return command;
        }

    }
}
