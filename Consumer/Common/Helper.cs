using Newtonsoft.Json.Linq;

namespace Consumer.Common
{
    public static class Helper
    {
        public static Message GetMessage(this string message)
        {
            return new Message()
            {
                Key = JObject.Parse(message)["Key"]?.ToString(),
                Value = JObject.Parse(message)["Value"]?.ToString(),
                Offset = JObject.Parse(message)["Offset"]?.ToString(),
                Partition = JObject.Parse(message)["Partition"]?.ToString()
            };
        }

        public static MessageWithHeader GetMessageWithHeader(this string message)
        {
            var parsedMessage = JObject.Parse(message);
            var headers = parsedMessage["Headers"]?.ToObject<List<Header>>() ?? [];

            return new MessageWithHeader()
            {
                Key = parsedMessage["Key"]?.ToString(),
                Value = parsedMessage["Value"]?.ToString(),
                Timestamp = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                Topic = "topic", // required field, value ignored though
                Offset = 1,      // required field, value ignored though
                Partition = 1,   // required field, value ignored though
                Headers = headers
            };
        }
    }
}
