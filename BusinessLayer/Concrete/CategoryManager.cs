using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Add(Category entity)
        {
            _categoryDal.Add(entity);
        }
        public void Delete(Category entity)
        {
            _categoryDal.Delete(entity);
        }

        public Category EditStatus(int id)
        {
            var category = _categoryDal.GetById(x => x.Id == id);
            if (category.Status == true)
            {
                category.Status = false;
                _categoryDal.Update(category);
            }
            else
            {
                category.Status = true;
                _categoryDal.Update(category);
            }
            return category;
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(x => x.Id == id);
        }
        public void Update(Category entity)
        {
            _categoryDal.Update(entity);
        }
    }
}
