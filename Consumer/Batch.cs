using Consumer.Common;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Consumer
{
    public class Batch
    {
        [Function(nameof(RunBatch))]
        public static void RunBatch(
            [KafkaTrigger("%BootstrapServers%",
                "%Topic%",
                Username = "%SaslUsername%",
                Password = "%SaslPassword%",
                Protocol = BrokerProtocol.SaslSsl,
                AuthenticationMode = BrokerAuthenticationMode.Plain,
                IsBatched = true,
                ConsumerGroup = "$Default")] string[] events, FunctionContext context)
        {
            foreach (var kevent in events)
            {
                var logger = context.GetLogger("KafkaFunction");

                var message = kevent.GetMessage();

                logger.LogInformation(
                    $"**** Message Key: {message.Key}, OffSet: {message.Offset}, Partition: {message.Partition}");
            }
        }

        [Function(nameof(RunBatchSecond))]
        public static void RunBatchSecond(
            [KafkaTrigger("%BootstrapServers%",
                "%Topic%",
                Username = "%SaslUsername%",
                Password = "%SaslPassword%",
                Protocol = BrokerProtocol.SaslSsl,
                AuthenticationMode = BrokerAuthenticationMode.Plain,
                IsBatched = true,
                ConsumerGroup = "$Default")] string[] events, FunctionContext context)
        {
            foreach (var kevent in events)
            {
                var logger = context.GetLogger("KafkaFunction");

                var message = kevent.GetMessage();

                logger.LogInformation(
                    $"---- Message Key: {message.Key}, OffSet: {message.Offset}, Partition: {message.Partition}");
            }
        }

        [Function(nameof(RunBatchThird))]
        public static void RunBatchThird(
            [KafkaTrigger("%BootstrapServers%",
                "%Topic%",
                Username = "%SaslUsername%",
                Password = "%SaslPassword%",
                Protocol = BrokerProtocol.SaslSsl,
                AuthenticationMode = BrokerAuthenticationMode.Plain,
                IsBatched = true,
                ConsumerGroup = "$Default")] string[] events, FunctionContext context)
        {
            foreach (var kevent in events)
            {
                var logger = context.GetLogger("KafkaFunction");

                var message = kevent.GetMessage();

                logger.LogInformation(
                    $"==== Message Key: {message.Key}, OffSet: {message.Offset}, Partition: {message.Partition}");
            }
        }
    }
}
