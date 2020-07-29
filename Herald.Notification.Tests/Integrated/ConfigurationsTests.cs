using Herald.Notification.Sns.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Xunit;

namespace Herald.Notification.Tests.Integrated
{
    public class ConfigurationsTests
    {
        [Fact]
        public void ShouldAddNotificationSns()
        {
            var services = new ServiceCollection();

            var configuration = (IConfiguration)new ConfigurationBuilder()
                .AddInMemoryCollection(new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("KEY", "VALUE"),
                })
                .Build();

            services.AddSingleton(configuration);

            services.AddNotificationSns(setup =>
            {
                setup.ServiceURL = "localhost:4576";
                setup.Region = "us-east-1";
                setup.ClientId = "123456789012";
            });

            var serviceProvider = services.BuildServiceProvider();

            var service = serviceProvider.GetService<INotification>();

            Assert.IsType<Sns.NotificationSns>(service);
        }
    }
}
