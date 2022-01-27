﻿using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService : IService<Category>
    {
        Category EditStatus(int status);
    }
}
