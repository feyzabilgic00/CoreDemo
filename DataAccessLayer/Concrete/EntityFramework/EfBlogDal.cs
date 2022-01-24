using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfBlogDal : EfGenericRepositoryBase<Blog>, IBlogDal
    {
        private readonly DbContext _context;
        public EfBlogDal(DbContext context) : base(context)
        {
            _context = context;
        }
        public List<Blog> GetListWithCategory(Expression<Func<Blog, bool>> filter = null)
        {
            //Include metodu ile hangi entity 'i dahil edeceksem onu 
            //include edebilmemi sağlıyor.
            return filter == null ? _context.Set<Blog>().Include(b => b.Category).ToList()
                                  : _context.Set<Blog>().Include(b => b.Category).Where(filter).ToList();
        }

        public int NumberOfAuthorsBlogs(int writerId)
        {
            return _context.Set<Blog>().Where(x => x.WriterId == writerId).Count();
        }

        public int NumberOfBlogsInCategory(int categoryId)
        {
            return _context.Set<Blog>().Where(x => x.CategoryId == categoryId).Count();
        }

        public int TotalNumberOfBlogs()
        {
           return _context.Set<Blog>().Count();
        }
    }
}
