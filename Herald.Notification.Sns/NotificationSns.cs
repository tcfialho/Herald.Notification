using Amazon.SimpleNotificationService;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Herald.Notification.Sns.Configurations;
using Microsoft.Extensions.Options;

namespace Herald.Notification.Sns
{
    public class NotificationSns : INotification
    {
        private readonly IAmazonSimpleNotificationService _sns;
        private readonly NotificationOptions _options;

        public NotificationSns(IAmazonSimpleNotificationService sns, IOptions<NotificationOptions> options)
        {
            _sns = sns;
            _options = options.Value;
        }

        public async Task Publish<T>(T message) where T : class
        {
            await _sns.PublishAsync(_options.TopicArn, JsonConvert.SerializeObject(message));
        }
    }
}