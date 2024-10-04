using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public class HttpTrigger1
    {
        private readonly ILogger<HttpTrigger1> _logger;

        public HttpTrigger1(ILogger<HttpTrigger1> logger)
        {
            _logger = logger;
        }

        [Function("HttpTrigger1")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            // return all headers of the request
            // loop over them. store them in a dictionary that will be returned as a response
            var headers = req.Headers;
            var headersDictionary = new Dictionary<string, string>();

            foreach (var header in headers)
            {
                headersDictionary.Add(header.Key, header.Value);
            }

            return new OkObjectResult(headersDictionary);


        }
    }
}
