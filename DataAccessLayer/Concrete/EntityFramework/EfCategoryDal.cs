using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfCategoryDal: EfGenericRepositoryBase<Category>, ICategoryDal
    {
        public EfCategoryDal(DbContext context) : base(context)
        {

        }
    }
}
