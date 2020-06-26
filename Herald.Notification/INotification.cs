using System.Threading.Tasks;

namespace Herald.Notification
{
    public interface INotification
    {
        Task Publish<T>(T message) where T : class;
    }
}
