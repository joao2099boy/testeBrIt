using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AcessoApi;
using _20241022_ApiTeste.Application.Interfaces.AcessoApi;
using _20241022_ApiTeste.Application.Extensions;
using Refit;

namespace _20241022_ApiTesteJoao.Extension.ConfigureExternalServices;

public static class ConfigureExternalService
{
    public static void AddAcessoApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddRefitClient<IAcessoApiRequest>()
            .AddHttpMessageHandler<LoggingDelegatingHandler>() 
            .ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
            });

        services.AddScoped<IAcessoApiService, AcessoApiService>();
        services.AddTransient<LoggingDelegatingHandler>();
    }
}