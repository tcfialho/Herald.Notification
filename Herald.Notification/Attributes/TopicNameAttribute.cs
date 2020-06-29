using System;
using System.Collections.Generic;
using System.Text;

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
