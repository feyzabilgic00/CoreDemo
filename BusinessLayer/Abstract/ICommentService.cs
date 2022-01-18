using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ICommentService : IService<Comment>
    {
        List<Comment> GetComments(int id);
    }
}
