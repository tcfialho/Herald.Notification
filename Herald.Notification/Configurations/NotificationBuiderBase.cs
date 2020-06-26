using System;
using Microsoft.Extensions.DependencyInjection;

namespace Herald.Notification.Builder
{
    public abstract class NotificationBuiderBase : INotificationBuilder
    {        
        public IServiceCollection Services { get; }

        public NotificationBuiderBase(IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            Services = services;
        }
    }
}