using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationDal;
        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }
        public void Add(Notification entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Notification entity)
        {
            throw new NotImplementedException();
        }

        public List<Notification> GetAll()
        {
            return _notificationDal.GetAll();
        }

        public List<Notification> GetAllStatusTrue(bool status)
        {
            return _notificationDal.GetAll(x => x.Status == status);
        }

        public Notification GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Notification entity)
        {
            throw new NotImplementedException();
        }
    }
}
