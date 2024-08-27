using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Producer.Common;

namespace Producer
{
    public class KafkaOutputWithHeaders
    {
        [Function(nameof(KafkaOutputWithHeadersFunction))]

        public static MultipleOutputType KafkaOutputWithHeadersFunction(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequestData req,
            FunctionContext executionContext)
        {
            var log = executionContext.GetLogger("HttpFunction");
            log.LogInformation("C# HTTP trigger function processed a request.");

            var message = req.FunctionContext
                .BindingContext
                .BindingData["message"]?
                .ToString();

            // Reference: https://github.com/Azure/azure-functions-kafka-extension/blob/dev/samples/dotnet-isolated/confluent/KafkaOutputWithHeaders.cs

            string kevent = new Message()
            {
                Offset = 1, // required field, value ignored though
                Partition = 1, // required field, value ignored though
                Topic = "topic", // required field, value ignored though
                Timestamp = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                Key = "1",
                Value = message,
                Headers = new List<Header>()
                {
                    new() { Key = "sample1", Value = "test1" },
                    new() { Key = "sample2", Value = "test2" },
                }
            }.ToJson();

            var response = req.CreateResponse(HttpStatusCode.OK);
            return new MultipleOutputType()
            {
                Kevent = kevent,
                HttpResponse = response
            };
        }
    }
}
