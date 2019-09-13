using DRP.Core.CQRS.Abstractions.Commands;
using DRP.Core.CQRS.Abstractions.Events;
using DRP.Core.CQRS.Abstractions.Queries;
using DRP.Core.CQRS.DependencyInjection.Abstractions;

using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DRP.Core.CQRS.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterCommandHandler<TCommand, THandler>(this IServiceCollection services)
            where TCommand : ICommand
            where THandler : ICommandHandler<TCommand>
        {
            var handlerType = typeof(THandler);

            var decorators = GetDecorators<TCommand>(handlerType)
                .Where(p => p.BaseType == typeof(CommandHandlerDecorator<TCommand>) ||
                    p.GetInterfaces().Contains(typeof(IPipelineBehavior<TCommand, Unit>)));

            foreach (var decor in decorators)
            {
                if (decor.BaseType == typeof(CommandHandlerDecorator<TCommand>))
                    services.AddTransient(typeof(CommandHandlerDecorator<TCommand>), decor);
                else
                    services.AddTransient(typeof(IPipelineBehavior<TCommand, Unit>), decor);
            }

            return services;
        }

        public static IServiceCollection RegisterQueryHandler<TQuery, Tout, THandler>(this IServiceCollection services)
            where TQuery : IQuery<Tout>
            where Tout : class
            where THandler : IQueryHandler<TQuery, Tout>
        {
            var handlerType = typeof(THandler);

            var decorators = GetDecorators<TQuery>(handlerType)
                .Where(p => p.BaseType == typeof(QueryHandlerDecorator<TQuery, Tout>) ||
                    p.BaseType == typeof(IPipelineBehavior<TQuery, Tout>));

            foreach (var decor in decorators)
            {
                if (decor.BaseType == typeof(QueryHandlerDecorator<TQuery, Tout>))
                    services.AddTransient(typeof(QueryHandlerDecorator<TQuery, Tout>), decor);
                else
                    services.AddTransient(typeof(IPipelineBehavior<TQuery, Tout>), decor);
            }

            return services;
        }

        public static IServiceCollection AddCQRS(this IServiceCollection services, Assembly assembly)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient<ICommandBus, CommandBus>();
            services.AddTransient<IQueryBus, QueryBus>();
            services.AddTransient<IEventBus, EventBus>();

            return services;
        }

        public static IServiceCollection AddModule<TModule>(this IServiceCollection services)
            where TModule : class, IModule
        {
            services.AddSingleton<TModule, TModule>();
            services.AddSingleton<IModule, TModule>(f => f.GetService<TModule>());
            services.BuildServiceProvider().GetService<TModule>().Configure(services);

            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }

        private static IEnumerable<Type> GetDecorators<T>(Type handler) =>
            handler.GetCustomAttributes(false)
                .Where(p => p is HandlerDecoratorAttribute)
                .Select(p => ((HandlerDecoratorAttribute)p).Decorator)
                .Where(p => p.GetGenericArguments().Contains(typeof(T)));

    }
}
