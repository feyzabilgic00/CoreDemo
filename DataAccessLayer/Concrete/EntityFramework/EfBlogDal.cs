using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfBlogDal : EfGenericRepositoryBase<Blog>, IBlogDal
    {
        public EfBlogDal(DbContext context) : base(context)
        {

        }
    }
}
