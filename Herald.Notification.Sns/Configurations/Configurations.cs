using System;

using Amazon;
using Amazon.Extensions.NETCore.Setup;
using Amazon.SimpleNotificationService;

using Herald.Notification.Sns.Attributes.Reader;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Herald.Notification.Sns.Configurations
{
    public static class Configurations
    {
        public static ISnsNotificationBuider AddNotificationSns(this IServiceCollection services, Action<NotificationOptions> options)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            services.Configure(options);
            var messageQueueOptions = new NotificationOptions();
            options?.Invoke(messageQueueOptions);
            services.TryAddSingleton(messageQueueOptions);

            services.AddSingleton<INotificationAttributesReader, NotificationAttributesReader>();
            services.TryAddSingleton<INotification, NotificationSns>();

            var awsOptions = new AWSOptions();

            if (string.IsNullOrWhiteSpace(messageQueueOptions.ServiceURL))
            {
                awsOptions.Region = RegionEndpoint.GetBySystemName(messageQueueOptions.Region);
            }
            else
            {
                awsOptions.Region = null;
                awsOptions.DefaultClientConfig.AllowAutoRedirect = false;
                awsOptions.DefaultClientConfig.EndpointDiscoveryEnabled = false;
                awsOptions.DefaultClientConfig.UseHttp = true;
                awsOptions.DefaultClientConfig.DisableHostPrefixInjection = true;
                awsOptions.DefaultClientConfig.ServiceURL = messageQueueOptions.ServiceURL;
            }

            services.AddDefaultAWSOptions(awsOptions);
            awsOptions.DefaultClientConfig.Validate();

            services.AddAWSService<IAmazonSimpleNotificationService>(awsOptions);

            return new SnsNotificationBuider(services);
        }
    }
}