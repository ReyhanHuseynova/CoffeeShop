using CoffeShop.DAL;
using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepositories<T> : IGenericDal<T> where T : class
    {
        private readonly AppDbContext _db;
        public GenericRepositories(AppDbContext db)
        {
            _db=db;
        }
        public void Create(T model)
        {
            _db.Add(model);
            _db.SaveChanges();
        }

        public void Delete(T model)
        {
            _db.Remove(model);
            _db.SaveChanges();
        }

        public List<T> GetAll()
        {
          return  _db.Set<T>().ToList();
        }

        public T GetById(int id)
        {
           return _db.Set<T>().Find(id);
        }

        public void Update(T model)
        {
            _db.Update(model);
            _db.SaveChanges();
        }
    }
}
