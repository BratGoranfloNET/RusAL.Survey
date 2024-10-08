﻿using RusAL.Survey.Commands.Abstract;
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
                    NewSurveyCommandService newSurvey,
                    SaveSurveyCommandService saveSurvey,
                    StatisticsCommandService statistics,
                    FindSurveyCommandService findSurvey,
                    DeleteSurveyCommandService deleteSurvey,
                    ListSurveyCommandService listSurvey,
                    ListToDaySurveyCommandService listTodaySurvey,
                    ZipSurveyCommandService zipSurvey,
                    ExitSurveyCommandService exit,
                    HelpSurveyCommandService help
                    )
        {
            Commands = new List<ConsoleCommand>(15)
            {
                Create("-new_profile", "Заполнение анкеты", newSurvey, true, false),
                Create("-save", "Сохранение анкеты", saveSurvey, true, false),
                Create("-statistics", "Статистика заполненных анкет", statistics, false, false),
                Create("-goto_question", "Вернуться к указанному вопросу", null, true, true),
                Create("-goto_prev_question", "Вернуться к предыдущему вопросу", null, true, true),
                Create("-restart_profile", "Заполнить анкету заново", null, true, true),
                Create("-find", "Найти анкету и показать данные анкеты", findSurvey, false, false),
                Create("-delete", "Удалить указанную анкету", deleteSurvey, false, false),
                Create("-list", "Показать список названий файлов всех сохранённых анкет", listSurvey, false, false),
                Create("-list_today", "Показать список названий файлов сохранённых анкет сегодня", listTodaySurvey, false,false),
                Create("-zip", "Запаковать указанную анкету", zipSurvey, false, false),
                Create("-exit", "Выйти из приложения", exit, false, false),
                Create("-help", "Показать список доступных команд", help, false, false)
            };

        }

        /// <summary>
        /// Создать команду.
        /// </summary>
        /// <param name="commandText">Текст команды.</param>
        /// <param name="title">Название.</param>
        /// <param name="service">Сервис команды.</param>
        private ConsoleCommand Create(string commandText, string title, CommandService service,  bool isSurvey, bool isInner)
        {
            var command = new ConsoleCommand
            {
                CommandText = commandText,
                Title = title,
                Service = service,
                IsSurveyCommand = isSurvey,
                IsInnerCommand = isInner               
            };

            return command;
        }
    }
}
