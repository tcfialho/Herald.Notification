using System;

namespace Herald.Notification.Sns.Attributes.Reader
{
    public interface INotificationAttributesReader
    {
        string GetTopicName(Type type);
    }
}