#pragma warning disable CS8601
namespace Behavioral.MediatorPattern.Utilities.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMediator(this IServiceCollection services, ServiceLifetime lifetime,
        params Type[] types)
    {
        var handlerInfo = new Dictionary<Type, Type>();
        foreach (var type in types)
        {
            var assembly = type.Assembly;
            var requests = GetClassesImplementingInterface(assembly, typeof(IRequest<>));
            var handlers = GetClassesImplementingInterface(assembly, typeof(IHandler<,>));

            requests.ForEach(x =>
            {
                handlerInfo[x] =
                    handlers.SingleOrDefault(xx => x == xx.GetInterface("IHandler`2")!.GetGenericArguments()[0]);
            });

            var serviceDescriptor = handlers.Select(x => new ServiceDescriptor(x, x, lifetime));
            services.TryAdd(serviceDescriptor);
        }

        services.AddSingleton<IMediator>(x => new Mediator(x.GetRequiredService, handlerInfo));

        return services;
    }

    private static List<Type> GetClassesImplementingInterface(Assembly assembly, Type matchedType)
    {
        return assembly.ExportedTypes
            .Where(x =>
            {
                var genericInterfaceTypes = x.GetInterfaces().Where(c => c.IsGenericType).ToList();
                var implementRequestType =
                    genericInterfaceTypes.Any(c => c.GetGenericTypeDefinition() == matchedType);

                return !x.IsInterface && !x.IsAbstract && implementRequestType;
            }).ToList();
    }
}