using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

using Herald.Notification.Sns;
using Herald.Notification.Sns.Attributes.Reader;
using Herald.Notification.Sns.Configurations;

using Microsoft.Extensions.Options;

using Moq;

using System;
using System.Net;
using System.Threading.Tasks;

using Xunit;

namespace Herald.Notification.Tests.Unit
{
    public partial class NotificationSnsTests
    {
        [Fact]
        public async Task ShouldPublish()
        {
            //Arrange
            var publishAsyncReturns = new PublishResponse() { HttpStatusCode = HttpStatusCode.OK };
            var options = new NotificationOptions() { Region = "us-east-1", ClientId = "123456789012" };
            var findTopicAsyncReturns = new Topic();

            var amazonSnsMock = new Mock<IAmazonSimpleNotificationService>();
            amazonSnsMock.Setup(x => x.PublishAsync(It.IsAny<string>(), It.IsAny<string>(), default))
                            .ReturnsAsync(publishAsyncReturns).Verifiable();

            var notification = new TestNotification { Message = Guid.NewGuid().ToString() };

            var notificationAttributesReaderMock = new Mock<INotificationAttributesReader>();
            notificationAttributesReaderMock.Setup(x => x.GetTopicName(It.IsAny<Type>()))
                                            .Returns($"{nameof(TestNotification)}Topic");

            var notificationSns = new NotificationSns(amazonSnsMock.Object, Options.Create(options), notificationAttributesReaderMock.Object);


            //Act
            await notificationSns.Publish(notification);

            //Assert
            amazonSnsMock.VerifyAll();
        }
    }
}
