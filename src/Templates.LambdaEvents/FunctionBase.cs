using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;
using Microsoft.Extensions.DependencyInjection;

namespace LambdaQuickStart.Templates.LambdaEvents.Abstraction
{
    public interface IApp
    {
        Task RunAsync<T>(T eventObj, ILambdaContext context);
    }

    public abstract class FunctionBase<TApp> where TApp : IApp
    {
        protected static ServiceProvider ServiceProvider { get; set; }

        /// <summary>
        /// The parameterless constructor is what Lambda uses to construct your instance the first time.
        /// It will only ever be called once for the lifetime of the container that it's running on.
        /// We want to build our ServiceProvider once, and then use the same provider in all subsequent
        /// Lambda invocations. This makes things like using local MemoryCache techniques viable (Just
        /// remember that you can never count on a locally cached item to be there!)
        /// </summary>
        public FunctionBase()
        {
            var services = new ServiceCollection();
            AddAppToServices(ConfigureServices(services));
            ServiceProvider = services.BuildServiceProvider();
        }

        public virtual async Task FunctionHandler(SQSEvent evnt, ILambdaContext context)
        {
            await ServiceProvider.GetService<TApp>().RunAsync(evnt, context);
        }

        /// <summary>
        /// Configure whatever dependency injection you like here
        /// </summary>
        /// <param name="services"></param>
        public virtual IServiceCollection ConfigureServices(IServiceCollection services) => services;
        private static void AddAppToServices(IServiceCollection services)
        {
            services.AddTransient(typeof(TApp));
        }

        /// <summary>
        /// Since we don't want to dispose of the ServiceProvider in the FunctionHandler, we will
        /// at least try to clean up after ourselves in the destructor for the class.
        /// </summary>
        ~FunctionBase()
        {
            ServiceProvider.Dispose();
        }
    }
}