using RusAL.Survey.Commands.Abstract;
using RusAL.Survey.Models;

namespace RusAL.Survey
{
    public class Startup
    {   
        /// <summary>
        /// Обработчик консольных команд.
        /// </summary>
        private readonly IConsoleCommandHandler _consoleCommandHandler;

        /// <summary>
        /// Стартовая точка приложения.
        /// </summary>
        public Startup(IConsoleCommandHandler consoleCommandHandler)
        {            
            _consoleCommandHandler = consoleCommandHandler;
        }

        public void Run()
        {
            bool hasErrors = false;                      
            var currSurvey = new SurveyItem();

            try
            {
                while (true)
                {
                    _consoleCommandHandler.Run(out hasErrors, currSurvey);                   
                }
            }
            catch (Exception exc)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Произошла ошибка: {exc.Message}\n{exc.StackTrace}");

                return;
            }
        }
    }
}
