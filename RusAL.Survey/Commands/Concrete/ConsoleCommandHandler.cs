﻿using Q101.ConsoleHelper.Abstract;
using RusAL.Survey.Commands.Abstract;
using RusAL.Survey.Models;
using System.Xml.Schema;

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

        public void Run( out bool hasErrors, out bool isExit, SurveyItem survey)
        {
            hasErrors = false;
            isExit  = false;
            var commandArg = string.Empty;
            int startQuestion = 0;

            var commandText = string.Empty;            

            commandText = _consoleHelper.GetStringFromConsole("Выберите действие:");
                       
            var command = _commandProvider.Commands.FirstOrDefault(c => commandText.Contains(c.CommandText));

            if (command != null) 
            {
                commandArg = commandText.Replace(command.CommandText, "");
            }
           
            if (command != null)
            {
                command.Service.Start(out hasErrors, survey, startQuestion, commandArg);
                // перезапускаем внутренние команды
                if (survey.NextQuestion > 0)
                {
                    command.Service.Start(out hasErrors, survey, survey.NextQuestion);
                }
                
            }
            else 
            {
                var commandErrorMessage = string.Empty;

                if (commandText == "-exit")
                {
                    isExit = true;
                }
                else 
                {
                   commandErrorMessage = $"Команда {commandText} не найдена";
                }
                             

                hasErrors = true;

                _consoleHelper.WriteMessageWithTimeStamp(commandErrorMessage, ConsoleColor.Red);
                
            }

        }

    }
}
