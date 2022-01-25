using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System.Linq.Expressions;

namespace DataAccessLayer.Abstract
{
    public interface IMessageDal : IGenericRepository<Message>
    {
        List<Message> GetListWithMessageByWriter(Expression<Func<Message, bool>> filter = null);
    }
}
