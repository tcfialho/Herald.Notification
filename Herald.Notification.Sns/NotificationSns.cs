using Amazon.SimpleNotificationService;
using Herald.Notification.Sns.Attributes.Reader;
using Herald.Notification.Sns.Configurations;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Herald.Notification.Sns
{
    public class NotificationSns : INotification
    {
        private readonly IAmazonSimpleNotificationService _sns;
        private readonly NotificationOptions _options;
        private readonly INotificationAttributesReader _notificationAttributesReader;

        public NotificationSns(IAmazonSimpleNotificationService sns,
                               IOptions<NotificationOptions> options,
                               INotificationAttributesReader notificationAttributesReader)
        {
            _sns = sns;
            _options = options.Value;
            _notificationAttributesReader = notificationAttributesReader;
        }

        public async Task Publish<T>(T message) where T : class
        {
            var topicName = _notificationAttributesReader.GetTopicName(typeof(T));

            var topicArn = $"arn:aws:sns:{_options.Region}:{_options.ClientId}:{topicName}".ToLower();

            await _sns.PublishAsync(topicArn, JsonConvert.SerializeObject(message));
        }
    }
}