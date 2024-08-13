using Q101.ConsoleHelper.Abstract;
using RusAL.Survey.Commands.Abstract;
using RusAL.Survey.Models;

namespace RusAL.Survey
{
    public class Startup
    {       

        /// <summary>
        /// Работа с консолью.
        /// </summary>
        private readonly IQ101ConsoleHelper _consoleHelper;

        /// <summary>
        /// Обработчик консольных команд.
        /// </summary>
        private readonly IConsoleCommandHandler _consoleCommandHandler;

        /// <summary>
        /// Стартовая точка приложения.
        /// </summary>
        public Startup(IQ101ConsoleHelper consoleHelper,
                       IConsoleCommandHandler consoleCommandHandler)
        {
            _consoleHelper = consoleHelper;
            _consoleCommandHandler = consoleCommandHandler;
        }

        public void Run()
        {

            bool hasErrors = false;
            bool isExit   = false;           
            var currSurvey = new SurveyItem();

            try
            {
                while (true)
                {
                    _consoleCommandHandler.Run(out hasErrors, out isExit, currSurvey);

                    if (isExit) break;
                }
            }
            catch (Exception exc)
            {
                _consoleHelper.WriteMessageWithTimeStamp(
                    $"Произошла ошибка: {exc.Message}\n{exc.StackTrace}",
                    ConsoleColor.Red);
                
                return;
            }
        }
    }
}
