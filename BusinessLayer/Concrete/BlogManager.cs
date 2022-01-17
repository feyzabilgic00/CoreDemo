﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal _blogDal;
        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }
        public void AddBlog(Blog blog)
        {
            throw new NotImplementedException();
        }

        public Blog GetBlog(int id)
        {
            return _blogDal.GetById(x => x.Id == id);
        }

        public List<Blog> GetBlogs()
        {
            return _blogDal.GetAll();
        }
        public List<Blog> GetLastThreeBlog()
        {
            return _blogDal.GetAll().Take(3).ToList();
        }
        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }

        public void RemoveBlog(Blog blog)
        {
            throw new NotImplementedException();
        }

        public void UpdateBlog(Blog blog)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetBlogById(int id)
        {
            return _blogDal.GetAll(x => x.Id == id);
        }

        public List<Blog> GetBlogListByWriter(int id)
        {
            return _blogDal.GetAll(x => x.Writer.Id == id);
        }
    }
}
