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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal= categoryDal;
        }
        public void TCreate(Category model)
        {
            _categoryDal.TCreate(model);
        }

        public void TDelete(Category model)
        {
            _categoryDal.TDelete(model);
        }

        public List<Category> TGetAll()
        {
          return  _categoryDal.TGetAll();
        }

        public Category TGetById(int id)
        {
           return _categoryDal.TGetById(id);
        }

        public void TUpdate(Category model)
        {
            _categoryDal.TUpdate(model);
        }
    }
}
