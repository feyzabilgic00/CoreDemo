using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IMessageService : IService<Message>
    {
        List<Message> GetInboxListByWriter(int senderId);
    }
}
