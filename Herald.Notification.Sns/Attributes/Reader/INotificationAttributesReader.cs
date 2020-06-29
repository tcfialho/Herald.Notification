using System;

namespace Herald.Notification.Sns.Attributes.Reader
{
    internal interface INotificationAttributesReader
    {
        string GetTopicName(Type type);
    }
}