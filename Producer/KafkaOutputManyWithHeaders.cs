using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker;
using System.Net;
using Producer.Common;
using Microsoft.Extensions.Logging;

namespace Producer
{
    public class KafkaOutputManyWithHeaders
    {
        [Function(nameof(KafkaOutputManyWithHeadersFunction))]

        public static MultipleOutputTypeForBatch KafkaOutputManyWithHeadersFunction(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequestData req,
            FunctionContext executionContext)
        {
            var log = executionContext.GetLogger("HttpFunction");
            log.LogInformation("C# HTTP trigger function processed a request.");
            var response = req.CreateResponse(HttpStatusCode.OK);

            string[] events = new string[2];
            events[0] = new Message()
            {
                Offset = 1, // required field, value ignored though
                Partition = 1, // required field, value ignored though
                Topic = "topic", // required field, value ignored though
                Timestamp = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                Key = "1",
                Value = "one",
                Headers = new List<Header>()
                {
                    new() { Key = "sample1", Value = "test1" },
                    new() { Key = "sample2", Value = "test2" },
                }
            }.ToJson();
            events[1] = new Message()
            {
                Offset = 1, // required field, value ignored though
                Partition = 1, // required field, value ignored though
                Topic = "topic", // required field, value ignored though
                Timestamp = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                Key = "2",
                Value = "two",
                Headers = new List<Header>()
                {
                    new() { Key = "sample1", Value = "test1" },
                    new() { Key = "sample2", Value = "test2" },
                }
            }.ToJson();

            return new MultipleOutputTypeForBatch()
            {
                Kevents = events,
                HttpResponse = response
            };
        }
    }
}
