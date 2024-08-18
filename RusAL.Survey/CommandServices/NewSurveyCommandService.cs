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
    public class NewSurveyCommandService : CommandService
    {       
        /// <summary>
        /// Работа с файлами
        /// </summary>
        private readonly IFileSurveyService _fileService;

        public NewSurveyCommandService(IFileSurveyService fileService)
        {           
            _fileService = fileService;
        }

        public override void StartSurvey(SurveyItem survey,  string commandArg)
        {           
            var exit = false;

            if (!survey.InnerCommand)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("ЗАПОЛНИТЕ АНКЕТУ !");
            }
            else
            {
                survey.InnerCommand = false;
                survey.StartQuestion = survey.NextQuestion;
            }
            
            var questions = SurveyHelper.GetQustions();            
            
            InputContext inputContext;

            for (int i = survey.StartQuestion; i < questions.Length; i++)
            {
                if (exit) break;              

                switch (i) {
                    case 0:
                        // ФИО                        
                        inputContext = new InputContext(new InputFioStrategy());
                        exit = inputContext.Input(i, questions[i], survey);
                        if (exit) continue;                                               
                        break;

                    case 1:
                        // Дата рождения
                        inputContext = new InputContext(new InputDateStrategy());
                        exit = inputContext.Input(i, questions[i], survey);
                        if (exit) continue;
                        break;

                    case 2:
                        // ЯП
                        inputContext = new InputContext(new InputLangStrategy());
                        exit = inputContext.Input(i, questions[i], survey);
                        if (exit) continue;
                        break;
                        
                    case 3:
                        // Опыт
                        inputContext = new InputContext(new InputExpStrategy());
                        exit = inputContext.Input(i, questions[i], survey);
                        if (exit) continue;
                        break;

                     case 4:
                        // Телефон
                        inputContext = new InputContext(new InputPhoneStrategy());
                        exit = inputContext.Input(i, questions[i], survey);
                        if (exit) continue;                        
                        break;
                }
            }            
        }
    }
}
