using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IBlogService : IService<Blog>
    {
        List<Blog> GetBlogListWithCategory();
        List<Blog> GetListWithCategoryByWriter(int id);
        List<Blog> GetLastThreeBlog();
        List<Blog> GetBlogListByWriter(int id);
        List<Blog> GetBlogById(int id);
    }
}
