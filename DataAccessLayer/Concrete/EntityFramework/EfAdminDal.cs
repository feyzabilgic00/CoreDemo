using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfAdminDal : EfGenericRepositoryBase<Admin>, IAdminDal
    {
        public EfAdminDal(DbContext context) : base(context)
        {
        }
    }
}
