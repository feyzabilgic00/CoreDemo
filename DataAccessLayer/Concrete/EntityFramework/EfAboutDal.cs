using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfAboutDal : EfGenericRepositoryBase<About>, IAboutDal
    {
        public EfAboutDal(DbContext context) : base(context)
        {

        }
    }
}
