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
    public class MenuManager : IMenuService
    {
        private readonly IMenuDal _menuDal;
        public MenuManager(IMenuDal menuDal)
        {
            _menuDal = menuDal;   
        }
        public void TCreate(Menu model)
        {
           _menuDal.TCreate(model);
        }

        public void TDelete(Menu model)
        {
          _menuDal.TDelete(model);
        }

        public List<Menu> TGetAll()
        {
          return  _menuDal.TGetAll();
        }

        public Menu TGetById(int id)
        {
            return _menuDal.TGetById(id);
        }

        public void TUpdate(Menu model)
        {
           _menuDal.TUpdate(model);
        }
    }
}
