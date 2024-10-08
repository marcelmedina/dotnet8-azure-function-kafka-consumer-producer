using Newtonsoft.Json;

namespace Consumer.Common
{
    public class MessageWithHeader
    {
        public int? Offset { get; set; }
        public int? Partition { get; set; }
        public string? Topic { get; set; }
        public string? Timestamp { get; set; }
        public string? Key { get; set; }
        public string? Value { get; set; }
        public List<Header>? Headers { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }
    }

    public class Header
    {
        public string? Key { get; set; }
        public string? Value { get; set; }
    }
}