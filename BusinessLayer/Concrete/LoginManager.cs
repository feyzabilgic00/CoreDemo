using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class LoginManager : ILoginService
    {
        private readonly IWriterDal _writerDal;
        public LoginManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }
        public Writer Login(Writer writer)
        {
           return _writerDal.GetById(x => x.Email == writer.Email && x.Password == writer.Password);
        }
    }
}
