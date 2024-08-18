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
        /// Провайдер консольных команд.
        /// </summary>
        private readonly IConsoleCommandProvider _commandProvider;

        /// <summary>
        /// Обработчик консольных команд.
        /// </summary>
        public ConsoleCommandHandler(IConsoleCommandProvider commandProvider)
        {            
            _commandProvider = commandProvider;
        }

        public void Run( out bool hasErrors,  SurveyItem survey)
        {
            hasErrors = false;            
            var commandArg = string.Empty;           

            var commandText = string.Empty;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Выберите действие:");
            var commandInputText = Console.ReadLine();
            
            var commandArr = commandInputText?.Trim().Split(" ");

            var length = commandArr?.Length;

            if (commandArr?.Length == 1)
            {
                commandText = commandArr[0];
            }
            else if (commandArr?.Length > 1)
            {
                commandText = commandArr[0];

                var from = Convert.ToInt32(commandArr?.Length - 1); 

                var newCommandArr = new string[(Int32)from];

                Array.Copy(commandArr, 1, newCommandArr, 0, from);

                commandArg =  string.Join(" ", newCommandArr);

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

                command.Service.Start(survey, commandArg, command.IsSurveyCommand);

                // Перезапускаем внутренние команды анкеты 
                if (survey.NextQuestion >= 0 && survey.InnerCommand)
                {
                   command.Service.Start(survey, commandArg, command.IsSurveyCommand);
                }    
                
            }
            else 
            {
                var commandErrorMessage = $"Команда {commandText} не найдена";                             

                hasErrors = true;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(commandErrorMessage);
            }
        }
    }
}
