using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

using Herald.Notification.Sns;
using Herald.Notification.Sns.Configurations;

using Microsoft.Extensions.Configuration;

using Moq;

using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
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
            var findTopicAsyncReturns = new Topic();

            var amazonSnsMock = new Mock<IAmazonSimpleNotificationService>();
            amazonSnsMock.Setup(x => x.PublishAsync(It.IsAny<string>(), It.IsAny<string>(), default))
                            .ReturnsAsync(publishAsyncReturns).Verifiable();
            amazonSnsMock.Setup(x => x.FindTopicAsync(It.IsAny<string>()))
                            .ReturnsAsync(findTopicAsyncReturns).Verifiable();

            var notificationSns = new NotificationSns(amazonSnsMock.Object);
            var notification = new TestNotification { Message = Guid.NewGuid().ToString() };

            //Act
            await notificationSns.Publish(notification);

            //Assert
            amazonSnsMock.VerifyAll();
        }
    }
}
