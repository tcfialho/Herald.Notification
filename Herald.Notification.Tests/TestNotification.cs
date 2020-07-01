using Herald.Notification.Attributes;

namespace Herald.Notification.Tests
{
    public class TestNotification
    {
        public string Message { get; set; }
    }

    [TopicName("expected-topic-name")]
    public class TestNotificationWithNammedTopic
    {
        public string Message { get; set; }
    }
}
