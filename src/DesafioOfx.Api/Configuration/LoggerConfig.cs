using Elmah.Io.AspNetCore;
using Elmah.Io.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace DesafioOfx.Api.Configuration
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLoggingConfig(this IServiceCollection services, IHostEnvironment env)
        {
            //Log de erros somente em ambiente de produção.
            if (env.IsProduction())
            {
                services.AddElmahIo(o =>
                {
                    o.ApiKey = "38bb9ae7cbe3462e9105c8b4503581c8";
                    o.LogId = new Guid("c4c4c185-aedc-4908-832c-c2d79ee335d5");
                });

                services.AddLogging(builder =>
                {
                    builder.AddElmahIo(o =>
                    {
                        o.ApiKey = "38bb9ae7cbe3462e9105c8b4503581c8";
                        o.LogId = new Guid("c4c4c185-aedc-4908-832c-c2d79ee335d5");
                    });
                    builder.AddFilter<ElmahIoLoggerProvider>(null, LogLevel.Warning);
                });
            }

            return services;
        }

        public static IApplicationBuilder UseLoggingConfiguration(this IApplicationBuilder app)
        {
            app.UseElmahIo();

            return app;
        }
    }
}
