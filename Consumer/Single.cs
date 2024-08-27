using Consumer.Common;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Consumer
{
    public class Single
    {
        [Function(nameof(RunSingle))]
        public static void RunSingle(
            [KafkaTrigger("%BootstrapServers%",
                "%Topic%",
                Username = "%SaslUsername%",
                Password = "%SaslPassword%",
                Protocol = BrokerProtocol.SaslSsl,
                AuthenticationMode = BrokerAuthenticationMode.Plain,
                ConsumerGroup = "$Default")] string eventData, FunctionContext context)
        {
            var logger = context.GetLogger("KafkaFunction");

            var message = eventData.GetMessage();

            logger.LogInformation(
                $"**** Message Key: {message.Key}, Value: {message.Value}, OffSet: {message.Offset}, Partition: {message.Partition}");
        }

        [Function(nameof(RunSingleSecond))]
        public static void RunSingleSecond(
            [KafkaTrigger("%BootstrapServers%",
                "%Topic%",
                Username = "%SaslUsername%",
                Password = "%SaslPassword%",
                Protocol = BrokerProtocol.SaslSsl,
                AuthenticationMode = BrokerAuthenticationMode.Plain,
                ConsumerGroup = "$Default")] string eventData, FunctionContext context)
        {
            var logger = context.GetLogger("KafkaFunction");

            var message = eventData.GetMessage();

            logger.LogInformation(
                $"---- Message Key: {message.Key}, Value: {message.Value}, OffSet: {message.Offset}, Partition: {message.Partition}");
        }

        [Function(nameof(RunSingleThird))]
        public static void RunSingleThird(
            [KafkaTrigger("%BootstrapServers%",
                "%Topic%",
                Username = "%SaslUsername%",
                Password = "%SaslPassword%",
                Protocol = BrokerProtocol.SaslSsl,
                AuthenticationMode = BrokerAuthenticationMode.Plain,
                ConsumerGroup = "$Default")] string eventData, FunctionContext context)
        {
            var logger = context.GetLogger("KafkaFunction");

            var message = eventData.GetMessage();

            logger.LogInformation(
                $"==== Message Key: {message.Key}, Value: {message.Value}, OffSet: {message.Offset}, Partition: {message.Partition}");
        }
    }
}
