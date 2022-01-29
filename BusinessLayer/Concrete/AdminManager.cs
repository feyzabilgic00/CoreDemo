using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        private readonly IAdminDal _adminDal;
        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }
        public void Add(Admin entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Admin entity)
        {
            throw new NotImplementedException();
        }

        public List<Admin> GetAll()
        {
            return _adminDal.GetAll();
        }

        public Admin GetById(int id)
        {
            return _adminDal.GetById(x => x.Id == id);
        }

        public void Update(Admin entity)
        {
            throw new NotImplementedException();
        }
    }
}
