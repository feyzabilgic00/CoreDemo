using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface INotificationService : IService<Notification>
    {
        List<Notification> GetAllStatusTrue(bool status);
    }
}
