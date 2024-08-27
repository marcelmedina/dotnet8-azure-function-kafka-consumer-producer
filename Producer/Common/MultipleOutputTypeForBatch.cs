using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace Producer.Common
{
    public class MultipleOutputTypeForBatch
    {
        [KafkaOutput("%BootstrapServers%",
            "%Topic%",
            Username = "%SaslUsername%",
            Password = "%SaslPassword%",
            Protocol = BrokerProtocol.SaslSsl,
            EnableIdempotence = true,
            AuthenticationMode = BrokerAuthenticationMode.Plain
        )]
        public string[] Kevents { get; set; }

        public HttpResponseData HttpResponse { get; set; }
    }
}
