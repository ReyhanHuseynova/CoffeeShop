using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        List<T> TGetAll();
        T TGetById(int id);
        void TCreate(T model);
        void TUpdate(T model);
        void TDelete(T model);
    }
}
