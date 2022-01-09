using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfContactDal : EfGenericRepositoryBase<Contact>, IContactDal
    {
        public EfContactDal(DbContext context) : base(context)
        {

        }
    }
}
