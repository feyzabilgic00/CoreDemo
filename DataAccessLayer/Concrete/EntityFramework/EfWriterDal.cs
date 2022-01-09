using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfWriterDal : EfGenericRepositoryBase<Writer>, IWriterDal
    {
        public EfWriterDal(DbContext context) : base(context)
        {

        }
    }
}
