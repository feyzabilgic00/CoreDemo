using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IBlogService : IService<Blog>
    {
        List<Blog> GetBlogListWithCategory();
        List<Blog> GetListWithCategoryByWriter(int id);
        List<Blog> GetLastThreeBlog();
        int TotalNumberOfBlogs();
        public int NumberOfAuthorsBlogs(int writerId);
        int NumberOfBlogsInCategory(int categoryId);
        List<Blog> GetBlogListByWriter(int id);
        List<Blog> GetBlogById(int id);
    }
}
