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
            throw new NotImplementedException();
        }

        public List<Message> GetInboxListByWriter(string receiver)
        {
            return _messageDal.GetAll(x => x.Receiver == receiver);
        }

        public void Update(Message entity)
        {
            throw new NotImplementedException();
        }
    }
}
