using System;

namespace Herald.Notification.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class TopicNameAttribute : Attribute
    {
        public string TopicName { get; }

        public TopicNameAttribute(string topic)
        {
            TopicName = topic;
        }
    }
}
