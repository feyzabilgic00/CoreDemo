using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ILoginService : IService<Writer>
    {
        Writer Login(Writer writer);
    }
}
