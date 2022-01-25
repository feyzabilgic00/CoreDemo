using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfMessageDal : EfGenericRepositoryBase<Message>, IMessageDal
    {
        private readonly DbContext _context;
        public EfMessageDal(DbContext context) : base(context)
        {
            _context = context;
        }

        public List<Message> GetListWithMessageByWriter(Expression<Func<Message, bool>> filter = null)
        {
            return filter == null ? _context.Set<Message>().Include(x => x.SenderUser).ToList()
                                  : _context.Set<Message>().Include(x => x.SenderUser).Where(filter).ToList();
        }
    }
}
