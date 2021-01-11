using DesafioOfx.Api.Extensions;
using DesafioOfx.Application.Services;
using DesafioOfx.Core.Communication.Mediator;
using DesafioOfx.Core.Messages.CommonMessages.Notifications;
using DesafioOfx.Data;
using DesafioOfx.Data.Repository;
using DesafioOfx.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DesafioOfx.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            #region Contextos
            services.AddScoped<MeuDbContext>();
            #endregion

            #region Repositorios
            services.AddScoped<IBancoRepository, BancoRepository>();
            #endregion

            #region Services
            services.AddScoped<IBancoService, BancoService>();
            #endregion

            #region Configuracaoes
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            
            //Identity
            services.AddScoped<IUser, AspNetUser>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            #endregion

            return services;
        }
    }
}
