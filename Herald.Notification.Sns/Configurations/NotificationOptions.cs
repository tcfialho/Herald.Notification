namespace Herald.Notification.Sns.Configurations
{
    public class NotificationOptions
    {
        public string ServiceURL { get; set; }
        public string Region { get; set; }
        public string ClientId { get; set; }
        public string TopicNameSufix { get; set; } = "Topic";
        public string Arn { get => $"arn:aws:sns:{Region}:{ClientId}"; }
    }
}