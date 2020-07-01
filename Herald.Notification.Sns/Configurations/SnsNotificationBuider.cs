using Herald.Notification.Builder;

using Microsoft.Extensions.DependencyInjection;

namespace Herald.Notification.Sns.Configurations
{
    public class SnsNotificationBuider : NotificationBuiderBase, ISnsNotificationBuider
    {
        public SnsNotificationBuider(IServiceCollection services) : base(services)
        {
        }
    }
}
