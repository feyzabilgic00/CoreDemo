using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        private readonly IWriterDal _writerDal;
        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void Add(Writer entity)
        {
            _writerDal.Add(entity);
        }
        public void Delete(Writer entity)
        {
            _writerDal.Delete(entity);
        }

        public List<Writer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Writer GetById(int id)
        {
            return _writerDal.GetById(x => x.Id == id);
        }

        public List<Writer> GetWriterById(int id)
        {
            return _writerDal.GetAll(x => x.Id == id);
        }

        public void Update(Writer entity)
        {
            _writerDal.Update(entity);
        }
    }
}
