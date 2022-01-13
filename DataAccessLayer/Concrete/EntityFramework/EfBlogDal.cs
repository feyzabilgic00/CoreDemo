using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfBlogDal : EfGenericRepositoryBase<Blog>, IBlogDal
    {
        private readonly DbContext _context;
        public EfBlogDal(DbContext context) : base(context)
        {
            _context = context;
        }

        public List<Blog> GetListWithCategory()
        {
            //Include metodu ile hangi entity 'i dahil edeceksem onu 
            //include edebilmemi sağlıyor.
            return _context.Set<Blog>().Include(b => b.Category).ToList();
        }
    }
}
