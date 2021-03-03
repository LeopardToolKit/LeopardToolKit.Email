using LeopardToolKit.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static partial class ServiceCollectionExtension
    {
        public static IServiceCollection AddEmailSender(this IServiceCollection services, Action<EmailOption> configBuilder)
        {
            services.TryAddSingleton<IEmailSender, SmtpEmailSender>();
            services.Configure(configBuilder);
            return services;
        }
        public static IServiceCollection AddEmailSender(this IServiceCollection services, IConfiguration configuration)
        {
            services.TryAddSingleton<IEmailSender, SmtpEmailSender>();
            services.Configure<EmailOption>(configuration);
            return services;
        }
    }
}
