using System.Threading.Tasks;
using Amazon.Lambda.Core;
using LambdaQuickStart.Templates.LambdaEvents.Abstraction;

namespace LambdaQuickStart.Templates.LambdaEvents
{
    public class App : IApp
    {
        // Inject your services into the constructor of app!

        //example
        // private readonly ISomethingService _somthingService;

        // public App(ISomethingService somthingService)
        // {
        //     _somthingService = somthingService;
        // }


        public App()
        {

        }

        public async Task RunAsync<SQSEvent>(SQSEvent sqsEvent, ILambdaContext context)
        {
            // actual business logic goes here

            // var someThing = _somthingService.GetThing();

            await Task.CompletedTask;
        }
    }
}