using Q101.ConsoleHelper.Abstract;
using RusAL.Survey.Commands.Abstract;
using RusAL.Survey.Models;

namespace RusAL.Survey.Commands.Concrete
{
    /// <summary>
    /// Обработчик консольных команд.
    /// </summary>
    public class ConsoleCommandHandler : IConsoleCommandHandler
    {
        /// <summary>
        /// Параметры командной строки.
        /// </summary>
        //private readonly ICmdArgs _cmdArgs;

        /// <summary>
        /// Работа с консолью.
        /// </summary>
        private readonly IQ101ConsoleHelper _consoleHelper;

        /// <summary>
        /// Провайдер консольных команд.
        /// </summary>
        private readonly IConsoleCommandProvider _commandProvider;

        /// <summary>
        /// Обработчик консольных команд.
        /// </summary>
        public ConsoleCommandHandler(IQ101ConsoleHelper consoleHelper,
                                     IConsoleCommandProvider commandProvider)
        {
            _consoleHelper = consoleHelper;
            _commandProvider = commandProvider;
        }

        public void Run( out bool hasErrors,  SurveyItem survey)
        {
            hasErrors = false;            
            var commandArg = string.Empty;
            int startQuestion = 0;

            var commandText = string.Empty;            

            var commandInputText = _consoleHelper.GetStringFromConsole("Выберите действие:");

            var commandArr = commandInputText.Trim().Split(" ");

            var length = commandArr.Length;


            if (commandArr.Length == 1)
            {
                commandText = commandArr[0];
            }
            else if (commandArr.Length == 2)
            {
                commandText = commandArr[0];
                commandArg  = commandArr[1];
            }
            else if (commandArr.Length == 3)
            {
                commandText = commandArr[0];
                commandArg  = commandArr[1] + " " + commandArr[2];
            }
            else 
            {
                var commandErrorMessage = $"Ошибка при вводе команды Команда {commandText} ";
                hasErrors = true;
                _consoleHelper.WriteMessageWithTimeStamp(commandErrorMessage, ConsoleColor.Red);
            }

            var command = _commandProvider.Commands.FirstOrDefault(c => c.CommandText == commandText && !c.IsInnerCommand);

                       
            if (command != null)
            {
                if (commandText == "-help") 
                {                   
                    Console.WriteLine("Список доступных команд: ");
                    foreach (var cmd in _commandProvider.Commands)
                    {
                        Console.WriteLine($"{cmd.CommandText}. {cmd.Title}", ConsoleColor.DarkYellow);                          
                    }
                }

                command.Service.Start(out hasErrors, survey, startQuestion, commandArg);
                // перезапускаем внутренние команды
                if (survey.NextQuestion > 0 & survey != null)
                {
                    command.Service.Start(out hasErrors, survey, survey.NextQuestion);
                }
                
            }
            else 
            {
                var commandErrorMessage = $"Команда {commandText} не найдена";                             

                hasErrors = true;

                _consoleHelper.WriteMessageWithTimeStamp(commandErrorMessage, ConsoleColor.Red);
                
            }

        }

    }
}
