﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal _blogDal;
        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }
        public List<Blog> GetLastThreeBlog()
        {
            return _blogDal.GetAll().Take(3).ToList();
        }
        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }
        public List<Blog> GetBlogById(int id)
        {
            return _blogDal.GetAll(x => x.Id == id);
        }

        public List<Blog> GetBlogListByWriter(int id)
        {
            return _blogDal.GetAll(x => x.Writer.Id == id);
        }

        public List<Blog> GetAll()
        {
            return _blogDal.GetAll();
        }

        public Blog GetById(int id)
        {
            return _blogDal.GetById(x => x.Id == id);
        }

        public void Add(Blog entity)
        {
            _blogDal.Add(entity);
        }

        public void Update(Blog entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Blog entity)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            return _blogDal.GetListWithCategory(x => x.WriterId == id);
        }
    }
}
