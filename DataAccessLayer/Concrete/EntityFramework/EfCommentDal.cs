using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfCommentDal : EfGenericRepositoryBase<Comment>, ICommentDal
    {
        public EfCommentDal(DbContext context) : base(context)
        {

        }
    }
}
