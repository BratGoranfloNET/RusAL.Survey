using Microsoft.Extensions.DependencyInjection;
using Q101.ConsoleHelper.Abstract;
using Q101.ConsoleHelper.Concrete;
using RusAL.Survey.Commands.Abstract;
using RusAL.Survey.Commands.Concrete;
using RusAL.Survey.Services.Abstract;
using RusAL.Survey.Services.Concrete;

namespace RusAL.Survey.Extensions
{
    /// <summary>
    /// Расширения провайдера сервисов IServiceCollection.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Регистрация зависимостей.
        /// </summary>
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            // Сервисы.
            services.AddTransient<IQ101ConsoleHelper, Q101ConsoleHelper>();

            //Сервисы команд.
            var commandServices = typeof(Program).Assembly
                .GetTypes().Where(t => t.GetInterfaces()
                    .Any(i => i == typeof(ICommandService)));

            foreach (var c in commandServices)
            {
                services.AddTransient(c);
            }

            // Обработчик команд.
            services.AddTransient<IConsoleCommandHandler, ConsoleCommandHandler>();
            services.AddTransient<IConsoleCommandProvider, ConsoleCommandProvider>();

            services.AddSingleton<IFileSurveyService, FileSurveyService>();
            

            // Старт приложения.
            services.AddTransient<Startup>();

            return services;

        }

    }
}
