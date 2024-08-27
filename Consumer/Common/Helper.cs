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
    }
}
