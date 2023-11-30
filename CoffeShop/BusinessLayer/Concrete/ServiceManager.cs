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
    public class ServiceManager : IServiceTableService
    {
      private readonly  IServiceDal _serviceDal;
        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }
        public void TCreate(Service model)
        {
            _serviceDal.TCreate(model);
        }

        public void TDelete(Service model)
        {
            _serviceDal.TDelete(model);
        }

        public List<Service> TGetAll()
        {
            return _serviceDal.TGetAll();
        }

        public Service TGetById(int id)
        {
            return _serviceDal.TGetById(id);
        }

        public void TUpdate(Service model)
        {
            _serviceDal.TUpdate(model);
        }
    }
}
