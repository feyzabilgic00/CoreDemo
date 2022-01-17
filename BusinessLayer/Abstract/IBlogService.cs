using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogService
    {
        List<Blog> GetBlogs();
        List<Blog> GetBlogListWithCategory();
        List<Blog> GetBlogListByWriter(int id);
        Blog GetBlog(int id);
        List<Blog> GetBlogById(int id);
        void AddBlog(Blog blog);
        void RemoveBlog(Blog blog);
        void UpdateBlog(Blog blog);
    }
}
