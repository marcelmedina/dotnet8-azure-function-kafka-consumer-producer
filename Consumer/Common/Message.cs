namespace Consumer.Common
{
    public class Message
    {
        public string? Key { get; set; }
        public string? Value { get; set; }
        public string? Offset { get; set; }
        public string? Partition { get; set; }
    }
}
