using Herald.Notification.Sns.Configurations;

using System;
using System.Collections.Generic;
using System.Text;

using Xunit;

namespace Herald.Notification.Tests.Unit
{
    public class NotificationOptionsTests
    {
        [Fact]
        public void ShouldReturnTopicArn()
        {
            //Arrange            
            var notificationOptions = new NotificationOptions()
            {
                Region = "sa-east-1",
                ClientId = "1234567890"
            };
            var expectedTopicArn = $"arn:aws:sns:{notificationOptions.Region}:{notificationOptions.ClientId}".ToLower();

            //Act
            var topicArn = notificationOptions.TopicArn;

            //Assert
            Assert.Equal(expectedTopicArn, topicArn);
        }
    }
}
