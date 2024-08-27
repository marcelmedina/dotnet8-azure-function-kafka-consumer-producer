using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace Producer.Common
{
    public class MultipleOutputType
    {
        [KafkaOutput("%BootstrapServers%",
            "%Topic%",
            Username = "%SaslUsername%",
            Password = "%SaslPassword%",
            Protocol = BrokerProtocol.SaslSsl,
            EnableIdempotence = true,
            AuthenticationMode = BrokerAuthenticationMode.Plain
        )]
        public string? Kevent { get; set; }

        public HttpResponseData HttpResponse { get; set; }
    }
}
