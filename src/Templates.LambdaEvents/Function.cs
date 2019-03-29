using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;
using LambdaQuickStart.Templates.LambdaEvents.Abstraction;
using Microsoft.Extensions.DependencyInjection;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
namespace LambdaQuickStart.Templates.LambdaEvents
{
    public class Function : FunctionBase<App>
    {
        /// <summary>
        /// The parameterless constructor is what Lambda uses to construct your instance the first time.
        /// It will only ever be called once for the lifetime of the container that it's running on.
        /// We want to build our ServiceProvider once, and then use the same provider in all subsequent
        /// Lambda invocations. This makes things like using local MemoryCache techniques viable (Just
        /// remember that you can never count on a locally cached item to be there!)
        /// </summary>
        public Function() : base()
        {

        }

        /// <summary>
        /// ConfigureServices will only ever be run once on the creation of the container
        /// Enure that object scoping is correct or you will have issue
        /// </summary>
        public override IServiceCollection ConfigureServices(IServiceCollection services)
        {

            return services;
        }
    }
}