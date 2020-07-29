using Herald.Notification.Attributes;
using Herald.Notification.Sns.Configurations;

using Microsoft.Extensions.Configuration;

using System;
using System.Linq;
using System.Reflection;

namespace Herald.Notification.Sns.Attributes.Reader
{
    internal class NotificationAttributesReader : INotificationAttributesReader
    {
        private readonly NotificationOptions _options;
        private readonly IConfiguration _configuration;

        public NotificationAttributesReader(NotificationOptions options, IConfiguration configuration)
        {
            _options = options;
            _configuration = configuration;
        }

        public string GetTopicName(Type type)
        {
            var configuredName = _configuration[$"{nameof(NotificationOptions)}:{type.Name}Topic"];

            if (!string.IsNullOrWhiteSpace(configuredName))
            {
                return configuredName;
            }

            var topicNameAttribute = type.GetCustomAttributes().FirstOrDefault() as TopicNameAttribute;

            if (!string.IsNullOrWhiteSpace(topicNameAttribute.TopicName))
            {
                return topicNameAttribute.TopicName;
            }

            return string.Concat(type.Name, _options.TopicNameSufix);
        }
    }
}
