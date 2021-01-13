using AutoMapper;
using DesafioOfx.Api.Extensions;
using DesafioOfx.Application.AutoMapper;
using DesafioOfx.Application.Commands;
using DesafioOfx.Application.Queries;
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
            services.AddScoped<ContaContext>();
            #endregion

            #region Repositorios
            services.AddScoped<IContaRepository, ContaRepository>();
            #endregion
             

            #region Events

            #endregion

            #region Commands
            services.AddScoped<IRequestHandler<AdicionarLancamentoFinanceiroCommand, bool>, LancamentoFinanceiroCommandHandler>();
            #endregion

            #region Queries
            services.AddScoped<IContaQueries, ContaQueries>();



            #endregion


            #region Configuracaoes
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            
            //Identity
            services.AddScoped<IUser, AspNetUser>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));

            #endregion

            return services;
        }
    }
}
