using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Text;

using Herald.Notification.Sns.Configurations;

using Xunit;
using Herald.Notification.Sns;

namespace Herald.Notification.Tests.Integrated
{
    public class ConfigurationsTests
    {
        [Fact]
        public void ShouldAddNotificationSns()
        {
            var services = new ServiceCollection();

            services.AddNotificationSns(setup =>
            {
                setup.ServiceURL = "localhost:4576";
                setup.Region = "us-east-1";
            });

            var serviceProvider = services.BuildServiceProvider();

            var service = serviceProvider.GetService<INotification>();

            Assert.IsType<NotificationSns>(service);
        }
    }
}
