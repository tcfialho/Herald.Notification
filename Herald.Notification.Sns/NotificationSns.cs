using System.Xml;
using System.Runtime.Serialization;
using Amazon.SimpleNotificationService;
using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Threading;
using Herald.Notification;

namespace Herald.Notification.Sns
{
    public class NotificationSns : INotification
    {
        private readonly IAmazonSimpleNotificationService _sns;

        public NotificationSns(IAmazonSimpleNotificationService sns)
        {
            _sns = sns;
        }

        public async Task Publish<T>(T message) where T : class
        {
            var topicInfo = await Retry.WhileNull(3, 1000, async () => await _sns.FindTopicAsync(typeof(T).Name));

            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }
            
            if (topicInfo == null)
            {
                throw new ArgumentException($"Topic {typeof(T).Name} not found.");
            }

            var publishRespose = await _sns.PublishAsync(topicInfo.TopicArn, JsonConvert.SerializeObject(message));

            if (publishRespose.HttpStatusCode != HttpStatusCode.OK)
            {
                throw new ApplicationException();
            }
        }
    }

    public static class Retry
    {
        public static T WhileNull<T>(int retries, int delayMs, Func<T> operation) where T : class
        {
            T result = null;
            for (var retry = 0; retry < retries; retry++)
            {
                result = operation();
                if (result == null)
                {
                    Thread.Sleep(delayMs);
                    continue;
                }
            }
            return result;
        }
    }
}
