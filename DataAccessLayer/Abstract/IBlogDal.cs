﻿using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBlogDal:IGenericRepository<Blog>
    {
        List<Blog> GetListWithCategory(Expression<Func<Blog,bool>> filter = null);
        int TotalNumberOfBlogs();
        int NumberOfAuthorsBlogs(int writerId);
        int NumberOfBlogsInCategory(int categoryId);
    }
}
