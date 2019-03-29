# aws-lambda-dotnet-quickstart-templates
Quick start templates for aws lambda in c# .net core




### Quick start

This aim at using dependecy inject in aws lambda func base on aws events.

Simply implement the abstract FunctionBase
And if you want to use DI over ride ConfigureServices

Create your app that inherits IApp and add your depencies in the constructor and away you go.
Example Bellow

```c#
  public class App : IApp
    {
        // Inject your services into the constructor of app!
        private readonly ISomethingService _somthingService;

        public App(ISomethingService somthingService)
        {
            _somthingService = somthingService;
        }

        public async Task RunAsync<SQSEvent>(SQSEvent sqsEvent, ILambdaContext context)
        {
            // actual business logic goes here

            var someThing = await _somthingService.GetThingAsync();

            await Task.CompletedTask;
        }
    }

```