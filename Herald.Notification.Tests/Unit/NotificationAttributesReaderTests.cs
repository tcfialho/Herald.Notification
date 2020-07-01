using Herald.Notification.Sns.Configurations;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;
using Herald.Notification.Sns.Attributes.Reader;

namespace Herald.Notification.Tests.Unit
{
    public class NotificationAttributesReaderTests
    {
        [Fact]
        public void ShouldGetTopicNameFromTopicAttribute()
        {
            //Arrange
            var options = new NotificationOptions();
            var configurationMock = new Mock<IConfiguration>();
            var notificationAttributesReader = new NotificationAttributesReader(options, configurationMock.Object);

            //Act
            var topicName = notificationAttributesReader.GetTopicName(typeof(TestNotificationWithNammedTopic));

            //Assert
            Assert.Equal("expected-topic-name", topicName);
        }

        [Fact]
        public void ShouldGetTopicNameFromIConfiguration()
        {
            //Arrange            
            var options = new NotificationOptions();
            var configurationKey = $"{nameof(NotificationOptions)}:{nameof(TestNotification)}Topic";
            var configurationMock = new Mock<IConfiguration>();
            configurationMock.Setup(x => x[configurationKey]).Returns("configured-topic-name");

            var notificationAttributesReader = new NotificationAttributesReader(options, configurationMock.Object);

            //Act
            var topicName = notificationAttributesReader.GetTopicName(typeof(TestNotification));

            //Assert
            Assert.Equal("configured-topic-name", topicName);
        }
    }
}