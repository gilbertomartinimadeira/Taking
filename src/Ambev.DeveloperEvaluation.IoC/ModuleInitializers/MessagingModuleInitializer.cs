using Ambev.DeveloperEvaluation.Application.Interfaces;
using Ambev.DeveloperEvaluation.Messaging.EventPublishers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Ambev.DeveloperEvaluation.IoC.ModuleInitializers
{
    internal class MessagingModuleInitializer : IModuleInitializer
    {
        public void Initialize(WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IEventPublisher, SimpleEventPublisher>();
        }
    }
}
