using Consumer.Common;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Consumer
{
    public class MultipleOutputTypeForBatch
    {
        [KafkaOutput("%BootstrapServers%",
            "%TopicOutput%",
            Username = "%SaslUsername%",
            Password = "%SaslPassword%",
            Protocol = BrokerProtocol.SaslSsl,
            EnableIdempotence = true,
            AuthenticationMode = BrokerAuthenticationMode.Plain
        )]
        public string[] Kevents { get; set; }
    }

    public class BatchProducer
    {
        [Function(nameof(RunBatchProducer))]
        public static MultipleOutputTypeForBatch? RunBatchProducer(
            [KafkaTrigger("%BootstrapServers%",
                    "%Topic%",
                    Username = "%SaslUsername%",
                    Password = "%SaslPassword%",
                    Protocol = BrokerProtocol.SaslSsl,
                    AuthenticationMode = BrokerAuthenticationMode.Plain,
                    IsBatched = true,
                    ConsumerGroup = "$Default")] string[] events, FunctionContext context)
        {
            var logger = context.GetLogger("KafkaFunction");

            try
            {
                var eventWithHeaders = new List<MessageWithHeader>();

                foreach (var kevent in events)
                {
                    var message = kevent.GetMessageWithHeader();

                    logger.LogInformation($"**** Message: {message.Value}");

                    eventWithHeaders.Add(message);
                }

                return new MultipleOutputTypeForBatch()
                {
                    Kevents = eventWithHeaders.Select(e => e.ToJson()).ToArray() // Fix the ToJson call
                };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
            }

            return null;
        }
    }
}
