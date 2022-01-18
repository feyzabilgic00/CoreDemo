using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class LoginManager : ILoginService
    {
        private readonly IWriterDal _writerDal;
        public LoginManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void Add(Writer entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Writer entity)
        {
            throw new NotImplementedException();
        }

        public List<Writer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Writer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Writer Login(Writer writer)
        {
           return _writerDal.GetById(x => x.Email == writer.Email && x.Password == writer.Password);
        }

        public void Update(Writer entity)
        {
            throw new NotImplementedException();
        }
    }
}
