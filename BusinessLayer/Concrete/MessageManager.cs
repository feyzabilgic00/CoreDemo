using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;
        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }
        public void Add(Message entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Message entity)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetAll()
        {
            throw new NotImplementedException();
        }

        public Message GetById(int id)
        {
            return _messageDal.GetById(x => x.Id == id);
        }

        public List<Message> GetInboxListByWriter(int senderId)
        {
            return _messageDal.GetListWithMessageByWriter(x => x.SenderId == senderId);
        }

        public void Update(Message entity)
        {
            throw new NotImplementedException();
        }
    }
}
