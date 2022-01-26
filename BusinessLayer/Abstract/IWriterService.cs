using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IWriterService : IService<Writer>
    {
        List<Writer> GetWriterById(int id);
        int GetWriter(string userMail);
    }
}
