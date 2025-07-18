using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace MyFunctionApp;

public class HelloFunction
{
    private readonly ILogger _logger;

    public HelloFunction(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<HelloFunction>();
    }

    [Function("HelloFunction")]
    public async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        var response = req.CreateResponse(System.Net.HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
        await response.WriteStringAsync("Hello from .NET 9 Azure Function!");

        return response;
    }
}
