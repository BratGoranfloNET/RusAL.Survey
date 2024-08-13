using Microsoft.Extensions.DependencyInjection;
using RusAL.Survey.Extensions;

namespace RusAL.Survey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection()                    
                    .RegisterServices()
                    .BuildServiceProvider(true);


            var scope = services.CreateScope();

            scope.ServiceProvider.GetRequiredService<Startup>().Run();
        }
    }
}
