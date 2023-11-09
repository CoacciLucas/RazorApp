using Application.Commands;
using MediatR;
using System.Reflection;

public static class DependencyRegister
{
    public static void RegisterHandlers(IServiceCollection services)
    {
        var assembly = Assembly.Load("Application.Commands");
        var handlerTypes = assembly.GetTypes()
            .Where(t => t.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)));

        foreach (var handlerType in handlerTypes)
        {
            var requestType = handlerType.GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>))
                .Select(i => i.GetGenericArguments()[0])
                .First();

            services.AddTransient(typeof(IRequestHandler<,>).MakeGenericType(requestType, typeof(CommandResult)), handlerType);
        }
    }

    public static void RegisterRepositories(IServiceCollection services)
    {
        var assemblies = new List<Assembly>
    {
        Assembly.Load("Domain"),
        Assembly.Load("Infra.Data")
    };

        foreach (var assembly in assemblies)
        {
            var repositoryTypes = assembly.GetTypes()
                .Where(t => t.GetInterfaces()
                    .Any(i => i.Name.EndsWith("Repository")));

            foreach (var repositoryType in repositoryTypes)
            {
                var interfaceType = repositoryType.GetInterfaces()
                    .Where(i => i.Name.EndsWith("Repository"))
                    .First();

                services.AddTransient(interfaceType, repositoryType);
            }
        }
    }
    public static void RegisterServices(IServiceCollection services)
    {
        var assembly = Assembly.Load("Domain");
        var serviceTypes = assembly.GetTypes()
            .Where(t => t.GetInterfaces()
                .Any(i => i.Name.EndsWith("Service")));

        foreach (var serviceType in serviceTypes)
        {
            var interfaceType = serviceType.GetInterfaces()
                .Where(i => i.Name.EndsWith("Service"))
                .First();

            services.AddTransient(interfaceType, serviceType);
        }
    }
    public static void RegisterQueryHandlers(IServiceCollection services)
    {
        var assembly = Assembly.Load("Application.Reads");
        var handlerTypes = assembly.GetTypes()
            .Where(t => t.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)));

        foreach (var handlerType in handlerTypes)
        {
            var requestType = handlerType.GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>))
                .Select(i => i.GetGenericArguments()[0])
                .First();

            var responseType = handlerType.GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>))
                .Select(i => i.GetGenericArguments()[1])
                .First();

            services.AddTransient(typeof(IRequestHandler<,>).MakeGenericType(requestType, responseType), handlerType);
        }
    }

}
