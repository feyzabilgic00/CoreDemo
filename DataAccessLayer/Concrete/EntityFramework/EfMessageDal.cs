using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfMessageDal : EfGenericRepositoryBase<Message>, IMessageDal
    {
        public EfMessageDal(DbContext context) : base(context)
        {
        }
    }
}
