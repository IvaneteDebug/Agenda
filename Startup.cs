using Microsoft.Extensions.DependencyInjection;
using Agenda.Services;
using Agenda.Persistence;

namespace Agenda
{
    public class Startup
    {
        public static ServiceProvider ConfigureServices()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<InMemoryContatoContext>()  // Certifique-se de ter essa classe definida em algum lugar
                .AddScoped<IContatoService, ContatoService>()  // Certifique-se de ter essa classe definida em algum lugar
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}