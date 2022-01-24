using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfNotificationDal : EfGenericRepositoryBase<Notification>, INotificationDal
    {
        public EfNotificationDal(DbContext context) : base(context)
        {
        }
    }
}
