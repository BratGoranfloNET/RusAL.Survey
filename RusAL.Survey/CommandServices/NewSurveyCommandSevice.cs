using Q101.ConsoleHelper.Abstract;
using RusAL.Survey.Commands.Abstract;
using RusAL.Survey.Models;
using RusAL.Survey.Services.Abstract;
using RusAL.Survey.Helpers;
using RusAL.Survey.SurveyStrategy;

namespace RusAL.Survey.CommandServices
{
    /// <summary>
    /// Заполнить новую анкету
    /// </summary>
    public class NewSurveyCommandSevice : ICommandService
    {
        /// <summary>
        /// Работа с консолью.
        /// </summary>
        private readonly IQ101ConsoleHelper _consoleHelper;

        /// <summary>
        /// Работа с файлами
        /// </summary>
        private readonly IFileSurveyService _fileService;

        public NewSurveyCommandSevice(IQ101ConsoleHelper consoleHelper, IFileSurveyService fileService)
        {
            _consoleHelper = consoleHelper;
            _fileService = fileService;
        }

        public void Start(out bool hasErrors, SurveyItem survey, int startQuestion, string commandArg)
        {
            hasErrors = false;
            var exit = false;
            
            if (!survey.InnerCommand)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("ЗАПОЛНИТЕ АНКЕТУ !");
            }

            survey.InnerCommand = false;

            var qustions = SurveyHelper.GetQustions();            
            
            InputContext inputContext;

            for (int i = startQuestion; i < qustions.Length; i++)
            {
                if (exit) break;              

                switch (i) {
                    case 0:
                        // ФИО                        
                        inputContext = new InputContext(new InputFioStrategy());
                        exit = inputContext.Input(i, qustions[i], survey);
                        if (exit) continue;                                               
                        break;

                    case 1:
                        // Дата рождения
                        inputContext = new InputContext(new InputDateStrategy());
                        exit = inputContext.Input(i, qustions[i], survey);
                        if (exit) continue;
                        break;

                    case 2:
                        // ЯП
                        inputContext = new InputContext(new InputLangStrategy());
                        exit = inputContext.Input(i, qustions[i], survey);
                        if (exit) continue;
                        break;
                        
                    case 3:
                        // Опыт
                        inputContext = new InputContext(new InputExpStrategy());
                        exit = inputContext.Input(i, qustions[i], survey);
                        if (exit) continue;
                        break;

                     case 4:
                        // Телефон
                        inputContext = new InputContext(new InputPhoneStrategy());
                        exit = inputContext.Input(i, qustions[i], survey);
                        if (exit) continue;                        
                        break;
                }

            }

            
        }

    }
}
